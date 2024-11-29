db.createUser({
    user: "TestAutomationUser",
    pwd: "Password",
    roles: [{ role: "readWrite", db: "AutomationPracticeDB" }]
});

db = db.getSiblingDB('AutomationPracticeDB');

db.createCollection("LogsStorage");

db.createCollection("Sequences");

db.Sequences.insertOne({
    sequence_value: 0,
    sequence_name: "log_entries"
});
