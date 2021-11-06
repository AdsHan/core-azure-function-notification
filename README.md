# core-azure-function-notification
Criação de função para envio de e-mail utilizando o SendGrid. A função será acionada sempre que uma mensagem for inserida no RabbitMQ.

# Este projeto contém:
- Azure Functions;
- RabbitMQ como trigger;
- Envio de e-mail com SendGrid;

# Como executar:
Clonar / baixar o repositório em seu workplace.
Baixar o .Net Core SDK e o Visual Studio / Code mais recentes.
A infraestrutura da aplicação será criada através do docker compose /docker/docker_infrastructure.yml.
É necessário a criação de uma conta no SendGrid para obtenção da API KEY.

# Sobre
Este projeto foi desenvolvido por Anderson Hansen sob [MIT license](LICENSE).