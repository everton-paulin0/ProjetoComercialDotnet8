Projeto Comercial .NET 8
API desenvolvida em ASP.NET Core 8 para controle de produtos, estoque, movimentações, vendas e cálculo de comissões.
Inclui: - Cadastro de produtos - Movimentação de estoque (entrada e saída) - Cálculo de estoque por produto e estoque geral - Registro de vendas - Cálculo de comissões por valor e por vendedor
________________________________________
🛠 Tecnologias utilizadas
•	ASP.NET Core 8 Web API
•	Entity Framework Core 8
•	SQLite
•	Migrations + Seed de dados
________________________________________
🚀 Como executar o projeto
1. Restaurar dependências
dotnet restore
2. Aplicar as migrações e criar o banco
dotnet ef database update
3. Executar o projeto
dotnet run
A API iniciará em: https://localhost:51407 (ou porta atribuída automaticamente).
________________________________________
📌 Endpoints da API
📦 Produtos
➤ GET /api/produtos
Retorna a lista de produtos cadastrados.
➤ GET /api/produtos/{codigoProduto}
Retorna um único produto.
➤ POST /api/produtos
Cadastro de um novo produto.
➤ PUT /api/produtos/{id}
Atualiza dados de um produto.
________________________________________
📊 Estoque
➤ GET /api/estoque/produto/{codigoProduto}
Retorna estoque detalhado: - código - descrição - estoque calculado (entradas - saídas)
✔ Exemplo de resposta
{
  "codigoProduto": 101,
  "descricaoProduto": "Caneta Azul",
  "estoque": 148
}
________________________________________
➤ GET /api/estoque/geral
Retorna o estoque de todos os produtos com cálculo individual.
✔ Exemplo de resposta
[
  {
    "id": 1,
    "codigoProduto": 101,
    "descricaoProduto": "Caneta Azul",
    "estoque": 148
  },
  {
    "id": 2,
    "codigoProduto": 102,
    "descricaoProduto": "Caderno Universitário",
    "estoque": 150
  }
]
________________________________________
➤ POST /api/estoque/movimentar
Realiza movimentação de estoque.
✔ Exemplo do body
{
  "codigoProduto": 101,
  "quantidade": 5,
  "tipo": "ENTRADA",
  "descricao": "Reposição"
}
Retorna o estoque atualizado.
________________________________________
💵 Vendas
➤ POST /api/vendas
Registra uma nova venda.
✔ Exemplo
{
  "vendedor": "João",
  "valor": 120.50
}
________________________________________
🧮 Comissões
➤ GET /api/comissao/total
Retorna total de comissões por vendedor.
✔ Regra utilizada
•	Até R$ 100,00 → 0%
•	Entre R$ 100,00 e R$ 500,00 → 1%
•	Acima de R$ 500,00 → 5%
✔ Exemplo de resposta
{
  "João": 12.50,
  "Maria": 58.00
}
________________________________________
📑 Estrutura do Banco / Seed
Os produtos são criados automaticamente na primeira execução. Os IDs são gerados automaticamente (Identity).
________________________________________
📚 Melhorias Futuras
•	DTOs para requests/responses
•	Tratamento global de erros
•	Testes unitários
•	Logging estruturado
•	Versionamento da API (v1/v2)
