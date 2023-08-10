# Desafio Lucas Baldasso
Esse repositório é destinado ao controle e a entrega do desafio técnico desenvolvido.
Dentre as trilhas disponíveis para a realização do desafio, escolhi a trilha de backend.

### Tecnologias utilizadas

- .Net
- EntityFramework
- WebApi

## Como executar o projeto

- Clone o projeto e entre na pasta executando os comandos 
```
git clone https://github.com/1Baldasso/CardApi
cd CardApi
```

- Na pasta, abra seu editor de código de preferência, renomeie o arquivo ```appsettings.json.example``` para ```appsettings.json``` e insira uma string para ser a JwtSecret no campo indicado.

- Após isso, seu código estará pronto para execução.

- Execute o comando ```dotnet run --project DesafioAda --launch-profile http``` e a api estará disponível no path ```http://localhost:5000/```

- Existe um arquivo .http configurado para realizar as requisições exemplo para a API. Os dados podem e devem ser mudados, de acordo com o resultado esperado.

## Observações
- Baixei o frontend disponível porém deram alguns erros no ```yarn```

- O projeto usa **Entity Framework InMemory**, então os dados não se mantém entre as execuções do projeto.

- Apesar da existência do ExceptionMiddleware, o PostProcessor era executado antes de o Middleware ser capaz de tratar o erro, por isso nas rotas em que existem PostProcessors, é tratado a exception no próprio endpoint.

- O github contém todo o histórico de commits, desde o início do desenvolvimento até o final, mostrando o caminho percorrido.

- O swagger está disponível para a solução através do caminho ```http://localhost:5000/swagger/```