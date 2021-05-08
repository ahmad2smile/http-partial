from flask import Flask, Response
import time

app = Flask(__name__)

def handler():
    yield "["
    time.sleep(1)
    intr = 0
    while intr <= 5:
        yield f"{{\"item\": {intr}}}{', ' if intr < 5 else ''}" 
        intr += 1
        time.sleep(1)
    yield "]"

@app.route('/')
def hello_world():
    return Response(handler())