# 📘 InterventionManager

Application console C# illustrant les principaux Design Patterns à travers la gestion d'interventions techniques (maintenance, urgence...) dans le cadre d’un projet ESGI.

---

## 🎯 Objectif
Concevoir une application structurée autour de plusieurs Design Patterns :

- Factory Method
- Decorator
- Facade
- Observer
- Proxy (optionnel mais implémenté ici)

Chaque pattern est utilisé pour illustrer son rôle dans un cas concret de gestion d'interventions.

---

## 📦 Structure du projet

```text
InterventionManager/
├── Program.cs                     // Menu console interactif
├── Models/                        // Modèle de données (Technicien, Intervention abstraite)
├── Factory/                       // Pattern Factory Method
├── Decorator/                    // Pattern Decorator
├── Facade/                       // Pattern Facade
├── Observer/                     // Pattern Observer
├── Proxy/                        // Pattern Proxy (gestion des rôles)
```

---

## 🧩 Design Patterns utilisés

### 🔨 Factory Method
Permet de créer différents types d'interventions (Maintenance, Urgence).

- InterventionFactory + enum TypeIntervention
- MaintenanceIntervention et UrgenceIntervention héritent de Intervention

```csharp
var intervention = factory.CreerIntervention(TypeIntervention.Maintenance);
```

### 🎁 Decorator
Permet d'ajouter dynamiquement des fonctionnalités sans modifier la classe de base.

- SuiviGPSDecorator
- PiecesJointesDecorator

```csharp
intervention = new SuiviGPSDecorator(intervention);
intervention = new PiecesJointesDecorator(intervention);
```

### 🧰 Facade
Expose une API simplifiée via GestionnaireInterventions (Créer, Assigner, Sauvegarder).

```csharp
var gestionnaire = new GestionnaireInterventions(user);
gestionnaire.CreerIntervention(TypeIntervention.Maintenance);
```

### 📣 Observer
Notifie automatiquement des composants à chaque changement :

- ConsoleObserver : affiche sur la console
- LogObserver : écrit dans un fichier log

```csharp
intervention.Attach(new ConsoleObserver());
intervention.Attach(new LogObserver());
intervention.ChangerEtat("En cours");
```

### 🔐 Proxy
Gère les droits d’un utilisateur simulé : Lecture ou Écriture.

```csharp
IUser user = new UserProxy("Mohammed", Role.Ecriture);
user.Sauvegarder(intervention);
```

---

## 🧪 Menu console intégré

Le fichier Program.cs intègre un menu complet avec les fonctionnalités suivantes :

- Créer une intervention
- Lister les interventions
- Assigner un technicien
- Ajouter un décorateur (Suivi GPS / PJ)
- Changer l’état d’une intervention (déclenche notifications)
- Sauvegarder l’intervention (selon les droits)
- Créer / Lister les techniciens

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

+---------------------------+
| InterventionDecorator     |
+---------------------------+
       ↑             ↑
       |             |
+----------------+  +---------------------+
| SuiviGPS       |  | PiècesJointes       |
+----------------+  +---------------------+

GestionnaireInterventions
          ▲
          |
      IUser & Proxy
```

---

## ✅ Avancement du projet (Plan 10h)

| Étape | Tâche                                               | Temps estimé |
|-------|------------------------------------------------------|--------------|
|   1   | Analyse + modélisation objet                         | 1h           |
|   2   | Implémentation Factory                               | 1.5h         |
|   3   | Décorateurs + Facade                                 | 2h           |
|   4   | Observateurs + notifications                         | 1.5h         |
|   5   | Proxy + rôles utilisateur                            | 1.5h         |
|   6   | Intégration, console et menu                         | 1h           |
|   7   | README, UML, packaging                               | 1h           |

---

📎 Rendu final prêt : code, menu interactif, architecture modulaire, et respect 100% du cahier des charges.
