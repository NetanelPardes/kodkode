import mysql.connector

def get_connection():
    return mysql.connector.connect(
        host = "localhost",
        port = 3306,
        user = "root",
        password = "root",
        database = "soldiers_db"
    )

def get_schema() -> list:
    conn = get_connection()
    cunsor = conn.cursor()
    cunsor.execute("DESCRIBE soldiers")
    rows = cunsor.fetchall()
    cunsor.close()
    conn.close()
    return [{"column" : row[0] , "type" : row[1]} for row in rows]