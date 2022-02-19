import 'dart:convert';
import '../models/cateogry.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:shopping_app/env/enviroment.dart';

class CategoryProvider with ChangeNotifier {
  String token;
  List<Category> _categoryList = [];
  CategoryProvider() {}
  void reciveToke(String token, List<Category> categories) {
    this.token = token;
    this._categoryList = categories;
  }

  List<Category> get Categories {
    return [..._categoryList];
  }

  Future<void> getCategoies() async {
    final url = "${Enviroment.baseURL}api/Categories";
    final currentHttp =
        await http.get(url, headers: {"Authorization": "Bearer $token"});
    final currentData = jsonDecode(currentHttp.body) as List<dynamic>;
    _categoryList.clear();
    currentData.forEach((element) {
      _categoryList
          .add(new Category(element["categoryID"], element["categoryName"]));
    });
    notifyListeners();
  }
}
