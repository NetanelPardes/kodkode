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
    cursor.execute("DESCRIBE soldiers")
    rows = cursor.fetchall()
    cursor.close()
    conn.close()
    return [{"column" : row[0] , "type" : row[1]} for row in rows]

def crate_soldier(name:str,soldier_rank:str,unit:str, active :bool):
    conn = get_connection()
    cursor = conn.cursor()

    sql = "INSERT INTO soldiers(name,soldier_rank,unit, active) VALUES (%s,%s,%s,%s)"
    values = (name,soldier_rank,unit, active )

    cursor.execute(sql,values)
    conn.commit()

    new_id = cursor.lastrowid

    cursor.close()
    conn.close()

    return new_id


def update_soldier(sildier_id, new_data) -> bool:
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    set_parts = [f"{key} = %s" for key in new_data.keys()]
    set_clause = ", ".join(set_parts)

    sql = f"UPDATE soldiers set {set_clause} where id = %s"
    values = list(new_data.values()) + [sildier_id]

    cursor.execute(sql,values)
    conn.commit()

    changed = cursor.rowcount > 0

    cursor.close()
    conn.close()
    return changed