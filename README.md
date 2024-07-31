# Delivery Bike

Este repositório é o Back-End de um sistema desenvolvido como desafio técnico para vaga de desenvolvedor Back-End.

# 📌 Sobre o Projeto

Esta API é responsável por realizar o aluguel de motos. e possui como funcionalidades pricipais:
* Fornece Endpoints com as operações de acordo a regra de negócio estabelecida.
* Armazenamento dos dados no PostgreSQL.
* Armazenamento de arquivos em um Bucket S3 da AWS.

Testes unitários em Desenvolvimento ⚙️ na branch: feature/add-Unit-Tests

## 🚀 Utilizando sistema localmente com Docker

Essas instruções permitirão que você obtenha acesso ao projeto em operação na sua máquina local para fins de teste.

### 📋 Pré-requisitos

De quais coisas você precisa para instalar o software e como instalá-lo?

```
WSL
DOCKER DESKTOP
DOCKER COMPOSE
```

### 🔧 Instalação

Uma série de exemplos passo-a-passo que informam o que você deve executar para ter um ambiente de teste em execução.

```
Instalar o WSL
https://docs.docker.com/desktop/wsl/
```

```
Instalar o Docker Desktop e Docker compose
https://docs.docker.com/desktop/install/windows-install/
```

```
Clone este repositório em sua máquina local utilizando o seguinte comando: 
git clone https://github.com/manzanofp/Desafio-BackEnd.git
```

```
Navegue no terminal do windows até o diretório do projeto:
cd Deliver.Bike
Verifique se o arquivo docker-compose está nessa pasta para prosseguir
```

```
Criar as variaveis de ambiente a nível de infraestrutura com os comandos:

export DATABASECONNECTION="Server=db:5432;Database=DeliverBike; UID=postgres; PWD=123456; Include Error Detail=true"

export AWSACCESSKEYID=""

export AWSSECRETKEY=""

export AWSBUCKETNAME=""

```

```
execute a aplicação:
docker-compose up -d
```

```
encerrando a aplicação:
docker-compose down
```

### ⚙️ Utilização do sistema localmente com docker

Para utilizar a API acesse em seu navegador a seguinte url da documentação com o Swagger:
http://localhost:8080/swagger/index.html

Para utilizar o Client do banco de dados acesse a seguinte url:
http://localhost:8086/?pgsql=db&username=postgres&db=DeliverBike

preencha os dados de acesso ao banco conforme sua string de conexão.


## 🚀 Utilizando sistema localmente

Essas instruções permitirão que você obtenha acesso ao projeto em operação na sua máquina local para fins de desenvolvimento e teste.

### 📋 Pré-requisitos

De quais coisas você precisa para instalar o software e como instalá-lo?

```
C# e .NET 7
Visual Studio 2022
PostgreSQL
DBeaver
```

### 🔧 Instalação

Uma série de exemplos passo-a-passo que informam o que você deve executar para ter um ambiente de desenvolvimento em execução.

```
Instalar o .NET 7
https://dotnet.microsoft.com/pt-br/download/dotnet/7.0
```

```
Instalar o Visual Studio 2022
https://visualstudio.microsoft.com/pt-br/downloads/
```

```
Instalar o PostgreSQL
https://www.postgresql.org/download/
```

```
Instalar o DBeaver
https://dbeaver.io/download/
```

```
Clone este repositório em sua máquina local utilizando o seguinte comando: 
git clone https://github.com/manzanofp/Desafio-BackEnd.git
```

```
Navegue até o diretório Deliver.Bike e abra com o Visual Studio 2022 o arquivo chamado Deliver.Bike.Sln:
```

```
Selecione para inicialização o seguinte projeto: Deliver.Bike.API
```

```
Criar as variáveis de ambiente a nível de aplicação:
Clique no menu superior "Depurar" e em "Propriedades de Depuração"
```

```
No perfil HTTP coloque as seguintes variáveis em Nome e Valor:
ConnectionStrings__DatabaseConnection= Server=localhost;Database=DeliveryBike; UID=postgres; PWD=123456; Include Error Detail=true
```

```
No perfil IISExpress coloque as seguintes variáveis:
ASPNETCORE_ENVIRONMENT=Development,AWS_ACCESS_KEYID=AKIAXQ3XZJPY6WLAJPZN,AWS_SECRETKEY=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,AWS_BUCKETNAME=deliverbike-photos-bucket
```

```
Restaure as dependências do projeto com o comando:
dotnet restore
```

```
Compile e execute a aplicação:
dotnet run
```

### ⚙️ Utilização do sistema localmente

Após o comando run será aberto em seu navegador a API na seguinte url da documentação com o Swagger:
http://localhost:5047/swagger/index.html

Os dados serão armazenados em seu PostgreSQL local.

## 🛠️ Construído com

-   [C#](https://learn.microsoft.com/pt-br/dotnet/csharp/) - Linguagem de Programação
-   [.NET 7.0](https://learn.microsoft.com/pt-br/dotnet/fundamentals/) - Plataforma de desenvolvimento
-   [PostgreSQL](https://www.postgresql.org/docs/) - Sistema gerenciador de banco de dados relacional