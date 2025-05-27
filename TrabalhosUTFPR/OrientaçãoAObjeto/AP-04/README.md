🗓️ Sistema de Compromissos
Projeto desenvolvido em C# para a disciplina de Programação Orientada a Objetos da UTFPR. O sistema permite o gerenciamento de compromissos com suporte a participantes, anotações, locais com capacidade e persistência de dados em JSON.

✅ Funcionalidades
✅ Cadastro de compromissos com data, hora, local e descrição

✅ Inclusão de participantes e anotações em cada compromisso

✅ Validação da capacidade do local

✅ Persistência automática dos dados em arquivo .json

✅ Listagem dos compromissos cadastrados via menu

📁 Estrutura do Projeto
swift
Copiar
Editar
/Modelos/
├── Usuario.cs
├── Compromisso.cs
├── Participante.cs
├── Local.cs
└── Anotacao.cs

/Persistencia/
└── RepositorioCompromissos.cs

Program.cs
compromissos.json (gerado automaticamente)
▶️ Como Executar
Certifique-se de ter o .NET 6 SDK ou superior instalado:

Download do .NET

Clone o repositório:

bash
Copiar
Editar
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio
Execute o projeto:

bash
Copiar
Editar
dotnet run
💻 Uso
Ao iniciar, informe seu nome completo.

Use o menu numérico para:

Criar compromissos

Listar compromissos existentes

Durante a criação de um compromisso, o sistema solicitará:

Data, hora, descrição e local

Participantes (opcional)

Anotações (opcional)

O sistema valida automaticamente:

Se a data/hora é futura

Se o local comporta todos os participantes

Se os campos obrigatórios foram preenchidos

💾 Persistência
Os dados são armazenados no arquivo compromissos.json, localizado na raiz do projeto.

A persistência é feita automaticamente a cada operação de criação ou remoção de compromisso.

📝 Licença
Este projeto foi desenvolvido exclusivamente para fins acadêmicos e não possui fins comerciais.

✒️ Autores
-Gustavo Finkler Haas -Pablo Emanuel Cechim de Lima -Tawan Vitor Silva de Oliveira
