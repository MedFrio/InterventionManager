# 📘 InterventionManager

Application console C# illustrant les principaux Design Patterns à travers la gestion d'interventions techniques (maintenance, urgence...).

---

## 🎯 Objectif
Concevoir une application structurée autour de plusieurs Design Patterns :

- Factory Method
- Decorator
- Facade
- Observer
- Proxy (optionnel)

Chaque pattern est utilisé pour illustrer son rôle dans un cas concret de gestion d'interventions.

---

## 📦 Structure du projet

```text
InterventionManager/
│
├── Program.cs                     // Entrée de l'application
├── InterventionManager.csproj     
│
├── Models/                        // Modèle de données
│   ├── Technicien.cs
│   └── Intervention.cs (classe abstraite)
│
├── Factory/                       // Pattern Factory Method
│   ├── InterventionFactory.cs
│   ├── MaintenanceIntervention.cs
│   └── UrgenceIntervention.cs
│
├── Decorator/                    // Pattern Decorator
│   ├── InterventionDecorator.cs (abstrait)
│   ├── SuiviGPSDecorator.cs
│   └── PiecesJointesDecorator.cs
│
├── Facade/                       // Pattern Facade
│   └── GestionnaireInterventions.cs
│
├── Observer/                     // Pattern Observer
│   ├── IObserver.cs
│   ├── ConsoleObserver.cs
│   └── LogObserver.cs
│
├── Proxy/                        // Pattern Proxy
│   ├── IUser.cs
│   └── UserProxy.cs
```

---

## 🧩 Design Patterns utilisés

### 🔨 Factory Method
Permet de créer différents types d'interventions (Maintenance, Urgence, etc.).

- Fichier principal : `Factory/InterventionFactory.cs`
- Utilisation : abstraire la création selon le type demandé.

```csharp
Intervention intervention = factory.CreerIntervention(TypeIntervention.Maintenance);
```

### 🎁 Decorator
Permet d'ajouter dynamiquement des fonctionnalités sans modifier la classe de base.

- Fichiers : `Decorator/SuiviGPSDecorator.cs`, `Decorator/PiecesJointesDecorator.cs`
- Exemple :
```csharp
intervention = new SuiviGPSDecorator(intervention);
intervention = new PiecesJointesDecorator(intervention);
```

### 🧰 Facade
Expose une API simple pour interagir avec les interventions.

- Fichier : `Facade/GestionnaireInterventions.cs`
- Méthodes proposées : `CréerIntervention()`, `AssignerTechnicien()`, `Sauvegarder()`...

```csharp
GestionnaireInterventions gestionnaire = new GestionnaireInterventions();
gestionnaire.CreerIntervention("Maintenance");
```

### 📣 Observer
Notifie automatiquement les composants (console, fichier log) lorsqu’une intervention change.

- Fichiers : `Observer/IObserver.cs`, `ConsoleObserver.cs`, `LogObserver.cs`
- Exemple :
```csharp
intervention.AjouterObservateur(new ConsoleObserver());
intervention.AjouterObservateur(new LogObserver());
```

### 🔐 Proxy (optionnel mais présent)
Gère les droits des utilisateurs (lecture/écriture).

- Fichiers : `Proxy/IUser.cs`, `UserProxy.cs`
- Exemple :
```csharp
UserProxy user = new UserProxy("technicien", Role.Lecture);
user.Sauvegarder(intervention); // Ne fonctionnera pas si pas les droits
```

---

## ▶️ Exemple d'exécution

```csharp
var factory = new InterventionFactory();
var intervention = factory.CreerIntervention(TypeIntervention.Maintenance);
intervention = new SuiviGPSDecorator(intervention);
intervention.AjouterObservateur(new ConsoleObserver());

var gestionnaire = new GestionnaireInterventions();
gestionnaire.AssignerTechnicien(intervention, new Technicien("Ali"));
gestionnaire.Sauvegarder(intervention);
```

---

## 📈 UML (simplifié)

```
            +---------------------------+
            |     Intervention (abs)   |
            +---------------------------+
                      ↑
          +-----------+------------+
          |                        |
+-------------------+    +--------------------+
| Maintenance       |    | Urgence            |
+-------------------+    +--------------------+


+----------------------+       +--------------------------+
|    Intervention      |◄------+ InterventionDecorator    |
|                      |       +--------------------------+
+----------------------+              ↑             ↑
                                     |             |
                        +------------------+  +---------------------+
                        | SuiviGPSDecorator|  |PiecesJointesDecorator|
                        +------------------+  +---------------------+
```

---

## ✅ Avancement (Plan de travail 10h)

| Étape | Tâche                                               | Temps estimé |
|-------|------------------------------------------------------|--------------|
|   1   | Analyse + modélisation objet                         | 1h           |
|   2   | Implémentation Factory (Maintenance, Urgence)       | 2h           |
|   3   | Décorateurs + Façade                                | 2h           |
|   4   | Observateurs + Notification                         | 1.5h         |
|   5   | Proxy + Sécurité utilisateur                        | 1.5h         |
|   6   | Tests + intégration                                 | 1h           |
|   7   | README + UML + nettoyage                            | 1h           |