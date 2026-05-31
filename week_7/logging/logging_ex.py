#EX1
"""
תרגיל 1 – נכון / לא נכון
סמן V אם הטענה נכונה, X אם לא:
.1 ❌ print ו-logging הם שקולים לחלוטין
.2 ✅ DEBUG מתאים למידע מפורט בזמן פיתוח
.3 ❌ מותר לכתוב סיסמה בלוג אם היא מוצפנת
.4 ❌ WARNING אומר שהמערכת קרסה
.5 ✅ FileHandler שומר לוגים לקובץ
stack trace גם כולל logger.exception ✅ .6
.7 ❌ כדאי להשתמש ברמת לוג אחת בלבד לפשטות
"""

#EX2
"""
תרגיל 2 – התאמת רמת לוג
לכל תיאור, ציין את רמת הלוג המתאימה )ERROR / WARNING / INFO / DEBUG):
.1 משתמש התחבר בהצלחה: INFO
.2 קובץ קונפיגורציה לא נמצא: ERROR
.3 כניסה לפונקציה עם ערכי הפרמטרים: DEBUG
.4 מסד הנתונים לא זמין: ERROR
.5 מלאי מוצר נמוך מ5- יחידות: ERROR
.6 תהליך הזמנה הסתיים בהצלחה: INFO
"""

#EX3
"""
תרגיל 3 – זיהוי בעיות
מצא את הבעיה בכל לוג ותקן:
# לוג א
logger.error('User logged in successfully')
בעיה ותיקון: שזה לא הלוג הנכון, אמור להיות INFO
# לוג ב
logger.info('Login', email, password)
בעיה ותיקון: שאסור להכניס סיסמא ללוג, צריך לשים משתנה בוליאני
# לוג ג
print('ERROR: payment failed')
בעיה ותיקון: שלא משתמשים בפריט, משתמשים בלוג
פרינט נעלם אחרי שסוגרים את התכנית
"""

#EX4
"""
תרגיל 4 – מה מייצג כל שדה?
הסבר מה מייצג כל שדה בפורמט הבא:
'%(asctime)s | %(levelname)s | %(name)s | %(message)s'
%(asctime)s: הזמן שבו הודעת הלוג נוצר
%(levelname)s: רמת הלוג
%(name)s: שם הלוגר שיצר את הלוג
%(message)s: ההודעה עצמה ששלחנו ללוג
"""

#ex5
import logging
logging.basicConfig(level=logging.INFO, format='%(levelname)s | %(message)s')
logger = logging.getLogger("payments")
logger.info('Application started')

#ex6
def process_payment(user_id, amount):
    logger.info("Starting payment for user %s" ,user_id)
    if amount <= 0:
            logger.error('ERROR: Invalid amount')
            return
    if amount > 10000:
        logger.warning('WARNING: Large transaction')
    logger.info("Payment of %s completed for user %s", amount ,user_id)

process_payment(1234,50)
process_payment(1234,-1)
process_payment(1234,1000001)

#ex7
# logging.basicConfig(level=logging.INFO, format='%(levelname)s | %(message)s', filename="app.log")
logger = logging.getLogger(__name__)
logger.setLevel(logging.INFO)
file_handler = logging.FileHandler("app.log" , encoding="UTF-8")
formatter = logging.Formatter("%(asctime)s | %(levelname)s | %(name)s | %(message)s")
file_handler.setFormatter(formatter)
logger.addHandler(file_handler)

def payment(user_id, amount):
    logger.info("starting payment for %s" ,user_id)
    if amount < 0:
        logger.error("dont have")
    if amount > 500:
         logger.warning("Your place is about to be full.")
    logger.info("payment done for %s" ,user_id)

payment(1234,14)
payment(1234,501)
payment(1234,-3)

#ex8
def read_config(filepath):
    logger.debug("start debuging open file function")
    try:
        with open(filepath) as f:
            data = f.read()

        # TODO: הוסף INFO על הצלחה
        logger.info("successful file open")
        return data

    except FileNotFoundError:
        # TODO: הוסף exception log
        logger.exception("the file not found")

        return None
read_config("app.log")
# read_config("app1.log")

#ex9

#ex10
"""
logger.info('done')
#This message is too short and doesn't say what's going on.
logger.error('failed')
#It's not clear what the error is about, you need to be more specific.
logger.info('user=%s', user_id)
#It's great to have the object, but it doesn't say what happens with it.
"""

#ex11
"""
סווג כל אירוע מהמערכת לרמת הלוג הנכונה:
info
• אדמין נכנס למערכת הניהול
info
• שירות חיצוני לא מגיב
error
• פונקציית חישוב מס החלה לרוץ
info/debug
• תעודת SSL עומדת לפוג בעוד 7 ימים
warning
• הזמנה בוטלה על ידי לקוח
info
• תשלום נכשל 3 פעמים ברצף
error
"""

#ex12
import logging
logging.basicConfig(level=logging.DEBUG)
logger = logging.getLogger(__name__)

def register_user(email, password, age):
    logger.info("Starting user registration | email=%s | age=%s", email, age)
    if age < 18:
        logger.warning("User registration rejected: age below minimum | email=%s | age=%s",email,age)
        return
    logger.info("User registration validated | email=%s | password_provided=%s",email,bool(password))
    logger.info("User registration completed successfully | email=%s", email)

register_user("sendi8475@gamil.com" , 1234 , 12)
register_user("sendi8475@gamil.com" , 1234 , 19)

#ex13
from logging_setup import get_logger

logger = get_logger(__name__)


def create_user(username):
    logger.info("Creating user | username=%s", username)

    if not username:
        logger.error("Failed to create user | reason=username is empty")
        return

    logger.info("User created successfully | username=%s", username)

create_user("Netanel")
create_user("yosi")

#ex14
#בקובץ הנוסף
    
