class HttpException implements Exception {
  final String message;

  HttpException(this.message) {}
  @override
  String toString() {
    return message;
    // return super.toString(); // Instance of HttpException
  }
}

class HttpExceptionUserNameAndPasswordIsWrong implements Exception {
  HttpException() {}
  @override
  String toString() {
    return "UserName or password is wrong";
    // return super.toString(); // Instance of HttpException
  }
}
