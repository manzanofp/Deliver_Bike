using Amazon;
using Amazon.Runtime.Internal;
using Amazon.S3;
using Amazon.S3.Model;
using Deliver.Bike.Application.Abstractions;
using Deliver.Bike.Application.Features.DeliverManFeatures.Commands.UpdateProfilePhoto;
using Deliver.Bike.Domain.Entities.DeliverEntity;
using Deliver.Bike.Domain.Entities.DeliverManEntity.Repositories;
using Deliver.Bike.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Deliver.Bike.Application.Features.UploadFileFeatures.Commands.UploadProfilePhoto;

public class UploadCnhImageForS3Handler : ICommandHandler<UploadCnhImageForS3Command, string>
{
    private readonly IDeliverManRepository _deliveryManRepository;
    private readonly IMediator _mediator;
    private readonly ILogger<UpdateCnhImageHandler> _logger;
    private readonly AmazonS3Client _s3Client;
    private readonly string _bucketName;

    public UploadCnhImageForS3Handler(IDeliverManRepository deliveryManRepository, IMediator mediator, ILogger<UpdateCnhImageHandler> logger)
    {
        _deliveryManRepository = deliveryManRepository;
        _mediator = mediator;
        _logger = logger;
        _logger.LogWarning($"AWS_ACCESS_KEYID");
        _s3Client = new AmazonS3Client(Environment.GetEnvironmentVariable("AWS_ACCESS_KEYID"),
                Environment.GetEnvironmentVariable("AWS_SECRETKEY"),
                RegionEndpoint.USEast1);
        _bucketName = Environment.GetEnvironmentVariable("AWS_BUCKETNAME");
    }

    public async Task<Result<string>> Handle(UploadCnhImageForS3Command request, CancellationToken cancellationToken)
    {
        var deliverMan = await _deliveryManRepository.GetById(request.DeliverManId);
        if (deliverMan == null)
        {
            _logger.LogWarning($"DeliverMan with id: {request.DeliverManId} not found");
            return Result.WithError<string>($"DeliverMan with id: {request.DeliverManId} not found");
        }

        string? oldFileName = RemoveOldFile(request, deliverMan);

        var fileName = $"ID-{request.DeliverManId}.{request.UploadFileTypeEnum}";

        var uploadImage = await UploadImage(fileName, request.File);
        if (string.IsNullOrEmpty(uploadImage))
        {
            return Result.WithError<string>("Failed to upload image");
        }

        var url = $"https://{_bucketName}.s3.sa-east-1.amazonaws.com/{fileName}";

        var result = await UpdateEntityFromUpload(request, url, cancellationToken);

        if (result.IsSuccess && !string.IsNullOrEmpty(oldFileName))
        {
            try
            {
                await _s3Client.DeleteObjectAsync(_bucketName, oldFileName);
            }
            catch (Exception ex)
            {
                _logger.LogError($"CNH Image {request.DeliverManId} not found in bucket {_bucketName} with name {oldFileName}", ex);
            }
        }
        return result;
    }

    private async Task<Result<string>> UpdateEntityFromUpload(UploadCnhImageForS3Command request, string url, CancellationToken cancellationToken)
    {
        switch (request.UploadFileTypeEnum)
        {
            case UploadFileTypeEnum.Png:
                return await _mediator.Send(new UpdateCnhImageCommand(request.DeliverManId, url), cancellationToken);

            case UploadFileTypeEnum.Bmp:
                return await _mediator.Send(new UpdateCnhImageCommand(request.DeliverManId, url), cancellationToken);

            default:
                _logger.LogError($"Image upload failed: specified file type {request.UploadFileTypeEnum} does not exist");
                return Result.WithError<string>($"Image upload failed: specified file type {request.UploadFileTypeEnum} does not exist");
        }
    }

    private async Task<string> UploadImage(string fileName, IFormFile file)
    {
        var request = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = fileName,
            CannedACL = S3CannedACL.PublicRead,
            InputStream = file.OpenReadStream(),
        };
        request.Metadata.Add("Content-type", file.ContentType);

        var response = await _s3Client.PutObjectAsync(request);
        if (response == null)
            return string.Empty;

        return fileName;
    }

    private static string? RemoveOldFile(UploadCnhImageForS3Command request, DeliverMan? deliveryMan)
    {
        switch (request.UploadFileTypeEnum)
        {
            case UploadFileTypeEnum.Png:
                return deliveryMan?.CnhImage;

            case UploadFileTypeEnum.Bmp:
                return deliveryMan?.CnhImage;

            default:
                return null;
        }
    }
}
