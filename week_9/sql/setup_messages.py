import mysql.connector

conn = mysql.connector.connect(
    host = "localhost",
    port = 3306,
    user = "root",
    password = "root",
    database = "soldiers_db"
    )

cursor = conn.cursor()

create_messages_table_sql = """
CREATE TABLE IF NOT EXISTS messages(
id INT AUTO_INCREMENT PRIMARY KEY,
unit VARCHAR(100) NOT NULL,
classification ENUM('unclassified','confidential','secret','top_secret'),
content TEXT NOT NULL,
source VARCHAR(100),
created_at DATETIME DEFAULT NOW())
"""

cursor.execute(create_messages_table_sql)
conn.commit()

print("Table created successfully.")

cursor.close()
conn.close()
