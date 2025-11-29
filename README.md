# ProjetoComercial (.NET 8)
API ASP.NET Core (.NET 8) com SQLite, seguindo princípios SOLID.
Contém módulos: Vendas (comissões), Estoque (movimentações) e Juros (multa diária).

## Como rodar
1. Tenha o .NET 8 SDK instalado.
2. Abra terminal na pasta do projeto.
3. Execute:
   - `dotnet restore`
   - `dotnet build`
   - `dotnet run`

A primeira execução cria o arquivo `bd.db` (SQLite) e popula dados de seed a partir dos JSONs em /Data/seed.

### Endpoints principais
- `POST /api/vendas` - inserir venda
- `GET /api/vendas/comissoes` - calcular comissões por vendedor
- `POST /api/estoque/movimentar` - fazer movimentação (ENTRADA/SAIDA)
- `POST /api/juros` - calcular juros por valor e vencimento

Swagger em `/swagger` quando em Development.
