# Sistema de Agenda de Compromissos

## Descrição

Este é um sistema de agenda de compromissos desenvolvido em C# para console, com foco em Programação Orientada a Objetos (POO). O sistema permite o cadastro de usuários, registro de compromissos, associação de participantes, definição de local e adição de anotações, reforçando conceitos como abstração, encapsulamento, validação e associação entre objetos.

## Funcionalidades

- Cadastro de usuário responsável pela agenda.
- Registro de compromissos com data, hora, descrição e local.
- Associação de participantes a cada compromisso.
- Adição de anotações a cada compromisso.
- Validação da capacidade máxima do local.
- Listagem de todos os compromissos cadastrados para o usuário.
- Mensagens de sucesso e erro conforme as validações.

## Estrutura das Classes

- **Usuario**: Armazena o nome completo e a lista de compromissos do usuário.
- **Compromisso**: Armazena data/hora, descrição, usuário responsável, local, participantes e anotações.
- **Participante**: Armazena o nome completo e a lista de compromissos dos quais participa.
- **Local**: Armazena o nome do local e sua capacidade máxima.
- **Anotacao**: Armazena o texto da anotação e a data de criação.

## Como Usar

1. **Clone o repositório ou copie os arquivos para sua máquina.**
2. **Abra o projeto no Visual Studio ou VS Code.**
3. **Compile e execute o projeto.**
4. **No console, informe seu nome completo para iniciar.**
5. **Utilize o menu principal para registrar compromissos ou listar os já cadastrados.**

### Fluxo Básico

1. Informe seu nome completo.
2. Escolha a opção para registrar um novo compromisso.
   - Informe data e hora (futura), descrição, nome do local e capacidade.
   - Adicione participantes (opcional).
   - Adicione anotações (opcional).
3. O sistema valida as informações e registra o compromisso.
4. Você pode listar todos os compromissos cadastrados a qualquer momento.

## Exemplo de Uso

```
=== Sistema de Agenda de Compromissos ===
Informe seu nome completo: João Silva

Menu Principal:
1 - Registrar novo compromisso
2 - Listar compromissos
0 - Sair
Escolha uma opção: 1
Data e hora do compromisso (ex: 25/12/2025 14:00): 30/06/2025 09:00
Descrição: Reunião de Projeto
Nome do local: Sala 101
Capacidade do local: 5
Adicionar participante (deixe vazio para terminar): Maria
Adicionar participante (deixe vazio para terminar): Carlos
Adicionar participante (deixe vazio para terminar):
Adicionar anotação (deixe vazio para terminar): Levar documentos
Adicionar anotação (deixe vazio para terminar):

Compromisso registrado com sucesso!
```

## Requisitos

- .NET 6.0 ou superior
- Console do Windows

## Organização dos Arquivos

```
AP-03/
│
├── Modelo/
│   ├── Usuario.cs
│   ├── Compromisso.cs
│   ├── Participante.cs
│   ├── Local.cs
│   └── Anotacao.cs
│
└── Program.cs
```

## Observações

- O sistema realiza validações para garantir integridade dos dados (ex: data futura, capacidade do local, campos obrigatórios).
- As associações entre objetos seguem boas práticas de POO.
- O código pode ser expandido para incluir persistência em arquivos ou banco de dados, se desejado.

---

Desenvolvido para fins didáticos e prática de Programação Orientada a Objetos.

✒️ Autores
-Gustavo Finkler Hass - Guilherme Campos Feuser