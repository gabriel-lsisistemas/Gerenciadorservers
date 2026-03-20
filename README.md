# Gerenciadorservers

Aplicação Windows Forms desenvolvida em C# para monitoramento e reinicialização automática de executáveis utilizados em integrações e serviços locais.

O sistema garante que processos essenciais estejam sempre em execução, reiniciando automaticamente em horários programados e registrando logs de funcionamento.

---

## 📌 Funcionalidades

* Verifica executáveis ao iniciar o sistema
* Inicia automaticamente se não estiverem rodando
* Reinicia processos em horários programados
* Exibe log em tempo real na tela
* Evita falhas em integrações automáticas
* Controle simples via interface desktop

---

## 📌 Executáveis monitorados

O sistema controla os seguintes processos:

* IntegradorCreditos
* IntegradorRM
* Api Local Seculos

Os arquivos devem estar na mesma pasta do executável do Gerenciadorservers.

Exemplo:

```
Gerenciadorservers.exe
IntegradorCreditos.lnk
IntegradorRM.lnk
Api Local Seculos.exe
```

---

## 📌 Horários de reinicialização automática

Os processos são reiniciados automaticamente nos horários:

* 00:00
* 08:00

A verificação é feita a cada 1 minuto.

---

## 📌 Requisitos

* Windows 10 ou superior
* .NET 6 ou superior
* Permissão para executar processos
* Executáveis na mesma pasta do sistema

---

## 📌 Como executar

1. Compile o projeto no Visual Studio

ou

2. Execute o arquivo:

```
Gerenciadorservers.exe
```

O sistema iniciará automaticamente o monitoramento.

---

## 📌 Estrutura do projeto

```
Gerenciadorservers
 ├── Program.cs
 ├── Form1.cs
 ├── Form1.Designer.cs
 ├── Form1.resx
 ├── Gerenciadorservers.csproj
```

| Arquivo    | Função           |
| ---------- | ---------------- |
| Program.cs | Ponto de entrada |
| Form1.cs   | Lógica principal |
| Designer   | Interface        |
| csproj     | Configuração     |

---

## 📌 Funcionamento

Fluxo do sistema:

```
Inicia aplicação
↓
Verifica executáveis
↓
Inicia se necessário
↓
Timer roda a cada 1 minuto
↓
Se horário programado
↓
Reinicia executáveis
↓
Registra log
```

---

## 📌 Logs

O sistema mostra no painel:

```
[2026-03-20 08:00:00] IntegradorRM iniciado
[2026-03-20 08:00:00] Api Local Seculos reiniciado
```

---

## 📌 Uso recomendado

Servidor Windows
Integrações com ERP
Serviços locais
APIs internas
Automação de processos

---

## 📌 Melhorias futuras

* Arquivo de configuração
* Horários configuráveis
* Log em arquivo
* Executar como serviço Windows
* Monitoramento de travamento
* Ícone na bandeja

---

## 📌 Autor

Gabriel Rebouças
LSI Sistemas

---
