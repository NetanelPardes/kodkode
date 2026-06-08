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

def get_message_by_id(message_id: int) -> dict | None:
    result = {}
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)
    cursor.execute("SELECT * FROM messages")
    rows = cursor.fetchall()
    for row in rows:
        if row['id'] == message_id:
            result = row
    cursor.close()
    conn.close()
    return result
    
def create_message(unit: str, classification: str, content: str, source:str | None) -> int:
    conn = get_connection()
    cursor = conn.cursor()

    query = """  
    INSERT INTO messages(unit, classification,content,source)
    VALUES(%s,%s,%s,%s)
    """
    value = (unit,classification,content,source)
    cursor.execute(query ,value)
    conn.commit()
    new_id = cursor.lastrowid
    cursor.close()
    conn.close()
    return new_id

def update_message(message_id: int, data: dict) -> bool:
    conn = get_connection()
    cursor = conn.cursor()
    set_parts = [f"{key} = %s" for key in data.keys()]
    set_cluse = ", ".join(set_parts)
    sql = f"UPDATE messages  set {set_cluse} where id = %s"
    values = list(data.values()) + [message_id]
    cursor.execute(sql,values)
    conn.commit()
    changed = cursor.rowcount > 0
    cursor.close()
    conn.close()
    return changed

def delete_message(message_id: int) -> bool:
    conn = get_connection()
    cursor = conn.cursor()
    cursor.execute("DELETE from messages where id = %s" , (message_id,))
    conn.commit()
    deleted = cursor.rowcount > 0
    cursor.close()
    conn.close()
    return deleted