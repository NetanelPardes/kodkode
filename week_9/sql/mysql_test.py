import mysql.connector

conn = mysql.connector.connect(
    host="127.0.0.1",
    port=3306,
    user="root",
    password="secret"
)

cur = conn.cursor()

cur.execute("SHOW DATABASES")
print("Databases:", [row[0] for row in cur.fetchall()])

cur.execute("USE mydb")

cur.execute("SHOW TABLES")
print("Tables:", [row[0] for row in cur.fetchall()])

conn.close()