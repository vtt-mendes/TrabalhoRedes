```mermaid
flowchart TD
    A[Início] --> B[Conectar ao servidor]
    B --> C{Receber Menu}
    C -->|Mostrar Menu| D[Mostrar opções]
    D --> E{Escolher opção}
    
    E -->|1: Incrementar número| F[Enviar opção 1 ao servidor]
    F --> G[Receber resposta do servidor]
    G --> C
    
    E -->|2: Decrementar número| H[Enviar opção 2 ao servidor]
    H --> I[Receber resposta do servidor]
    I --> C
    
    E -->|3: Exibir número| J[Enviar opção 3 ao servidor]
    J --> K[Receber resposta do servidor]
    K --> C
    
    E -->|0: Sair| L[Enviar opção 0 ao servidor]
    L --> M[Receber resposta de encerramento]
    M --> N[Desconectar do servidor]
    
    E -->|Opção inválida| O[Receber mensagem de opção inválida]
    O --> C
