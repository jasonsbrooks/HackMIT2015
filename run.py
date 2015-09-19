import time
import requests

from flask import Flask, render_template, request, jsonify

app = Flask(__name__)


@app.route('/', methods=['GET', 'POST'])
def home():
    return "hello world"


if __name__ == '__main__':
    app.run(debug=True)
