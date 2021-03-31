# WebApi2
Creazione di una web api con 4 metodi CRUD delle Pratiche degli Esattori

Suddivisione progetto in layer specifici
  Creazione di un progetto DB per:
  - Creazione dello schema "user" usato per tutte le tabelle di seguito
  
  Creazione della tabella Pratiche con:
  - ID (autoincrementale)
  - CodiceCliente
  - Telefono

  Creazione della tabella Esattori con
  - ID (autoincrementale)
  - Nome
  - Cognome

  Creazione tabella PraticheEsattori con
  - ID (autoincrementale)
  - foreign key alla tabella Pratiche
  - foreign key alla tabella Esattori
  
  Esposizione di una web api (usando attribute routing) con i seguenti metodi:
  - CreaPratica - crea una nuova pratica
  - GetPratica - ritorna una pratica by id
  - AggiornaPratica - aggiorna una pratica
  - CancellaPratica - elimina una pratica (se non assegnata a nessun esattore)
  - AssegnaPratica (assegna una pratica esistente ad un esattore esistente)
 
  Accesso ai dati tramite Entity Framework
  
TASK FACOLTATIVI
  Gestione degli errori (HTTP 500 e 400)
  
  Creazione del metodo aggiuntivo
  - CancellaAssegnazione
  
  Utilizzo di Azure e deploy del progetto
  - Creazione gruppo di risorse
  - Creazione Database Sql Server e delle tabelle
  - Creazione Web App e deploy delle dll della solution
  
  In alternativa al punto precedente creazione del deploy su una cartella locale
