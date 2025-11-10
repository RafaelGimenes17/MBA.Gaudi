#!/bin/bash
# Script para executar testes com cobertura e gerar relatório (Linux/Mac)

echo "🧪 Executando testes com cobertura de código..."

# Limpar resultados anteriores
rm -rf TestResults

# Executar testes com cobertura
dotnet test MBA.Gaudi.sln --collect:"XPlat Code Coverage" --results-directory ./TestResults

# Gerar relatório HTML
echo ""
echo "📊 Gerando relatório de cobertura..."
reportgenerator -reports:"TestResults/**/coverage.cobertura.xml" -targetdir:"TestResults/CoverageReport" -reporttypes:Html

# Abrir relatório no navegador
echo ""
echo "✅ Relatório gerado com sucesso!"
echo "📂 Abrindo relatório no navegador..."
xdg-open TestResults/CoverageReport/index.html 2>/dev/null || open TestResults/CoverageReport/index.html

echo ""
echo "✨ Concluído! O relatório foi aberto no navegador."

