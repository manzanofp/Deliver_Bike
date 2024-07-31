using Deliver.Bike.Application.Abstractions;
using Microsoft.AspNetCore.Http;

namespace Deliver.Bike.Application.Features.UploadFileFeatures.Commands.UploadProfilePhoto;

public record UploadCnhImageForS3Command(Guid DeliverManId, UploadFileTypeEnum UploadFileTypeEnum, IFormFile File) : ICommand<string>;
