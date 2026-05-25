import logging

def get_logger(name):
    logger = logging.getLogger(name)
    logger.setLevel(logging.INFO)

    file_handler = logging.FileHandler("app.log" , encoding="UTF-8")
    stream_handler = logging.StreamHandler()

    formatter = logging.Formatter("%(asctime)s | %(levelname)s | %(name)s | %(message)s")

    file_handler.setFormatter(formatter)
    stream_handler.setFormatter(formatter)

    logger.addHandler(file_handler)
    logger.addHandler(stream_handler)

    return logger

#EX14
logger = logging.getLogger(__name__)
logger.setLevel(logging.INFO)

stream_handler = logging.StreamHandler()

formatter = logging.Formatter("%(asctime)s | %(levelname)s | %(request_id)s| %(user_id)s | %(name)s | %(message)s")


stream_handler.setFormatter(formatter)
logger.addHandler(stream_handler)


def process_request(request_id, user_id, action):
    logger.info("Starting request | action = %s ",action,extra = {"request_id": request_id,"user_id": user_id})
    logger.info("Processing request | action = %s",action,extra = {"request_id": request_id,"user_id": user_id})
    logger.info("Request completed successfully | action = %s ",action,extra = {"request_id": request_id,"user_id": user_id})

process_request(1234 , 'neta8475' , "post")