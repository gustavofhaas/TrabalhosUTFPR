# Trabalho de Programação Orientada a Objetos — UTFPR Medianeira

Este repositório reúne uma coleção de projetos desenvolvidos na disciplina de **Programação Orientada a Objetos (POO)** no curso de **Ciência da Computação** da **UTFPR - Campus Medianeira**. O objetivo é aplicar e consolidar conceitos fundamentais da programação orientada a objetos por meio de miniaplicações práticas e organizadas em projetos independentes.

---

## 🚀 Objetivo Geral

Desenvolver soluções completas para problemas diversos utilizando:

* Herança, polimorfismo, composição e associações
* Repositórios genéricos e especializados com persistência em JSON
* Separação de responsabilidades entre modelo, repositório e serviço
* Interação via console com menus dinâmicos e entrada do usuário

---

## 📦 Projetos Desenvolvidos

### 1. **Catálogo de Produtos**

* CRUD completo de produtos com nome, descrição, preço e estoque
* Persistência em JSON com repositório específico

### 2. **Biblioteca de Músicas**

* Uso de repositório genérico para entidades musicais
* Entrada interativa de dados e persistência automática

### 3. **Catálogo de Filmes com Filtro por Gênero**

* Repositório especializado com método `ObterPorGenero`
* Foco em consultas customizadas usando herança e genéricos

### 4. **Funcionários e Departamentos**

* Associação entre entidades (1\:N)
* Funcionários ligados a departamentos via `DepartamentoId`

### 5. **Pacientes com Faixa Etária**

* Filtragem de pacientes com base na idade
* Implementação de lógica personalizada no repositório

### 6. **Inventário de Equipamentos de TI**

* Repositório 100% em memória para testes rápidos
* Sem persistência em disco (útil para simulação e testes unitários)

### 7. **Sistema de Cardápio de Restaurante**

* Herança com `ItemCardapio`, `Prato` e `Bebida`
* Uso de polimorfismo na serialização JSON

### 8. **Gerenciador de Arquivos Digitais**

* Refatoração para herdar de `GenericJsonRepository`
* Foco em reuso e eliminação de duplicidade

### 9. **Reservas de Hotel com Status**

* Enum `StatusReserva` e filtro por status
* Repositório especializado para reservas

### 10. **Plataforma de Cursos Online com Serviço**

* Lógica de negócio separada em `CatalogoCursosService`
* Verificação de duplicidade antes de cadastrar cursos

---

## 🧰 Tecnologias Utilizadas

* Linguagem: C#
* Plataforma: .NET Console Application
* Persistência: System.Text.Json com arquivos `.json`

---

## 🧠 Conceitos Aplicados

* **Repositórios Genéricos** para centralizar operações CRUD
* **Herança e Polimorfismo** com classes base e subclasses (Ex: `ItemCardapio` → `Prato`, `Bebida`)
* **Associações** (1\:N) entre entidades (Ex: `Funcionario` → `Departamento`)
* **Enums** usados para representar estados e tipos (Ex: `StatusReserva`)
* **Camadas de Serviço** para validação de regras de negócio (Ex: cursos únicos)
* **Interação via Console** com menus limpos e funcionais

---

## ▶️ Como Executar

1. Certifique-se de ter o [.NET SDK](https://dotnet.microsoft.com/) instalado
2. Acesse a pasta de qualquer projeto pelo terminal
3. Execute:

```bash
dotnet run
```

---

## 👨‍💻 Autor

Desenvolvido por **Gustavo Finkler Haas** como parte do trabalho prático de **Programação Orientada a Objetos** no curso de Ciência da Computação — UTFPR Medianeira.

---

## 📬 Contato

* Email: gustavofhaas142gmail.com
* GitHub: https://github.com/gustavofhaas
