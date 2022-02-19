import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:shopping_app/http-exception/httpException.dart';

import '../env/enviroment.dart';
import 'package:http/http.dart' as http;

class AuthProvider with ChangeNotifier {
  int _userID;
  String _token;
  DateTime _expirationDate;
  String get Token {
    if (_token == null) {
      return null;
    }
    if (_token.isEmpty || _expirationDate.isAfter(_expirationDate)) {
      return null;
    } else {
      return _token;
    }
  }

  bool get isAuth {
    return Token != null;
  }

  Future<void> loginUser(String userName, String password) async {
    final url = "${Enviroment.baseURL}Auth/Login";
    var response = await http.post(url,
        body: json.encode({'userName': userName, 'password': password}),
        headers: {'Content-Type': "application/json"});
    if (response.statusCode == 200) {
      _token = json.decode(response.body)['token'];
      _userID = jsonDecode(response.body)['userID'];
      _expirationDate = DateTime.parse(jsonDecode(response.body)['expireDate']);
      print(response.body);
      notifyListeners();
    } else {
      if (response.statusCode == 401) {
        throw HttpExceptionUserNameAndPasswordIsWrong();
      }
    }
  }
}
