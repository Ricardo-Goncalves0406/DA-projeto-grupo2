
# Checklist - Projeto Final iTasks

## 📌 **Requisitos Gerais**
- [x] Sistema de login com username único
- [ ] Diferenciação entre usuários (Programador/Gestor)
- [ ] CRUD de usuários (apenas Gestor)
- [ ] CRUD de Tipos de Tarefas (apenas Gestor)
- [ ] Persistência de dados via SQL Server + Entity Framework
- [ ] Proteções contra erros inesperados no código
- [ ] Menu dinâmico conforme tipo de usuário logado

---

## 👥 **Gestão de Usuários**
- [ ] Formulário de Gestão de Utilizadores (CRUD)
- [ ] Associação obrigatória de Programador a um Gestor
- [ ] Validação de username único

---

## 📋 **Gestão de Tarefas**
- [ ] Formulário de Detalhes da Tarefa (Criação/Edição/Visualização)
- [ ] Tarefas iniciam em "ToDo" e seguem fluxo Kanban
- [ ] Restrições de estado:
  - [ ] Tarefas "Done" não podem ser alteradas
  - [ ] Programador só pode ter 2 tarefas "Doing" simultaneamente
  - [ ] Ordem de execução definida pelo Gestor (validação de ordens duplicadas)
- [ ] Datas automáticas:
  - [ ] Data de criação ao criar tarefa
  - [ ] Data real de início ao mover para "Doing"
  - [ ] Data real de fim ao mover para "Done"

---

## 🖥️ **Formulários Obrigatórios**
- [ ] **Login**: Validação de credenciais e armazenamento de ID de sessão
- [ ] **Kanban**: Listas "ToDo", "Doing", "Done" com drag-and-drop (ou botões)
- [ ] **Gestão de Utilizadores**
- [ ] **Gestão de Tipos de Tarefas**
- [ ] **Detalhes da Tarefa** (modo leitura para Programadores)
- [ ] **Consulta de Tarefas em Curso** (apenas Gestor)
- [ ] **Consulta de Tarefas Concluídas** (diferentes views para Gestor/Programador)
- [ ] **Exportação para CSV** (apenas Gestor, campos específicos)

---

## 📊 **Relatórios e Estatísticas**
- [ ] Lista de tarefas concluídas com tempo real vs. previsto (Gestor)
- [ ] Lista de tarefas em curso com tempo restante/atraso (Gestor)
- [ ] Algoritmo de previsão de tempo para tarefas "ToDo" (baseado em StoryPoints)
- [ ] Grid de tarefas concluídas por Programador (com tempo de execução)

---

## 📧 **Adenda (Funcionalidades Extra - Época Normal)**
- [ ] **Entidade "Projeto"**:
  - [ ] CRUD de Projetos (apenas Gestor)
  - [ ] Associação de Tarefas a Projetos
  - [ ] Filtro de tarefas por Projeto no Kanban
- [ ] **Nova Listagem**:
  - [ ] Estatísticas por Projeto (tarefas dentro/fora do prazo, programadores envolvidos)
- [ ] **Envio de Email**:
  - [ ] Notificação ao Gestor quando tarefa é concluída (com dados do Projeto, Tarefa e Programador)
- [ ] Persistência adicional para dados de Projetos

---

## 🛠️ **Tecnologias e Arquitetura**
- [ ] Padrão MVC
- [ ] Entity Framework configurado
- [ ] Código organizado e documentado
- [ ] Manual de utilização no relatório
- [ ] Ficheiro README.txt com instruções de instalação

---

## 📅 **Entrega**
- [ ] Relatório com justificativas de design e manual de uso
- [ ] Projeto em ZIP (código fonte + README)
- [ ] Nome do arquivo conforme padrão (nomes e números dos alunos)
