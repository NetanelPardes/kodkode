import mysql.connector


def get_connection():
    return mysql.connector.connect(
        host="localhost",
        port=3306,
        user="root",
        password="root",
        database="soldiers_db"
    )


def setup():
    conn = get_connection()
    cursor = conn.cursor()

    create_table_sql = """
    CREATE TABLE IF NOT EXISTS soldiers (
        id INT AUTO_INCREMENT PRIMARY KEY,
        name VARCHAR(100) NOT NULL,
        soldier_rank VARCHAR(100),
        unit VARCHAR(100),
        active BOOLEAN DEFAULT TRUE
    )
    """

    cursor.execute(create_table_sql)
    conn.commit()

    cursor.close()
    conn.close()


def get_schema() -> list:
    conn = get_connection()
    cursor = conn.cursor()

    cursor.execute("DESCRIBE soldiers")
    rows = cursor.fetchall()

    cursor.close()
    conn.close()

    return [
        {
            "column": row[0],
            "type": row[1],
            "null": row[2],
            "key": row[3],
            "default": row[4],
            "extra": row[5]
        }
        for row in rows
    ]


def create_soldier(name: str, soldier_rank: str | None, unit: str | None, active: bool = True):
    conn = get_connection()
    cursor = conn.cursor()

    sql = """
    INSERT INTO soldiers (name, soldier_rank, unit, active)
    VALUES (%s, %s, %s, %s)
    """

    values = (name, soldier_rank, unit, active)

    cursor.execute(sql, values)
    conn.commit()

    new_id = cursor.lastrowid

    cursor.close()
    conn.close()

    return new_id


def update_soldier(soldier_id: int, new_data: dict) -> bool:
    if not new_data:
        return False

    allowed_columns = ["name", "soldier_rank", "unit", "active"]

    for key in new_data.keys():
        if key not in allowed_columns:
            raise ValueError(f"Invalid column name: {key}")

    conn = get_connection()
    cursor = conn.cursor()

    set_parts = [f"{key} = %s" for key in new_data.keys()]
    set_clause = ", ".join(set_parts)

    sql = f"UPDATE soldiers SET {set_clause} WHERE id = %s"
    values = list(new_data.values()) + [soldier_id]

    cursor.execute(sql, values)
    conn.commit()

    changed = cursor.rowcount > 0

    cursor.close()
    conn.close()

    return changed


def delete_soldier(soldier_id: int) -> bool:
    conn = get_connection()
    cursor = conn.cursor()

    cursor.execute("DELETE FROM soldiers WHERE id = %s", (soldier_id,))
    conn.commit()

    deleted = cursor.rowcount > 0

    cursor.close()
    conn.close()

    return deleted


def get_all() -> list:
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    cursor.execute("SELECT * FROM soldiers")
    rows = cursor.fetchall()

    cursor.close()
    conn.close()

    return rows


def get_by_id(soldier_id: int) -> dict | None:
    conn = get_connection()
    cursor = conn.cursor(dictionary=True)

    cursor.execute("SELECT * FROM soldiers WHERE id = %s", (soldier_id,))
    row = cursor.fetchone()

    cursor.close()
    conn.close()

    return row