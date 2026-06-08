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
    cursor = conn.cursor()
    cursor.execute("DESCRIBE messages")
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return [{"column" : row[0] , "type" : row[1]} for row in rows]

def get_all_messages():
    conn = get_connection()
    cursor = conn.cursor()
    cursor.execute("SELECT * FROM messages")
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return rows

def add_new_message(new_message):
    conn = get_connection()
    cursor = conn.cursor()

    query = """  
    INSERT INTO messages(unit, classification,content,source)
    VALUES(%s,%s,%s,%s)
    """

    value = (new_message["unit"],new_message["classification"],new_message["content"],new_message["source"])
    

    cursor.execute(query ,value)

    conn.commit()

    new_id = cursor.lastrowid

    cursor.close()
    conn.close()

    return new_id

def get_all_messages_by_classification(classification):
    result = []
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)
    cursor.execute("SELECT * FROM messages")
    rows = cursor.fetchall()
    for row in rows:
        if row['classification'] == classification:
            result.append(row)
    cursor.close()
    conn.close()
    return result