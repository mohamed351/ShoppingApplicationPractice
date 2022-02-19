import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:shopping_app/models/cateogry.dart';
import 'package:shopping_app/providers/category_provider.dart';

class CateogryScreen extends StatefulWidget {
  static const routerName = "/categoryScreen";
  CateogryScreen();

  @override
  State<CateogryScreen> createState() => _CateogryScreenState();
}

class _CateogryScreenState extends State<CateogryScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Category"),
      ),
      body: FutureBuilder(
        future: Provider.of<CategoryProvider>(context, listen: false)
            .getCategoies(),
        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(
              child: CircularProgressIndicator(),
            );
          }
          return RefreshIndicator(
              child: CategoryGridScreen(),
              onRefresh: Provider.of<CategoryProvider>(context).getCategoies);
        },
      ),
    );
  }
}

class CategoryGridScreen extends StatelessWidget {
  CategoryGridScreen();

  @override
  Widget build(BuildContext context) {
    return Consumer<CategoryProvider>(builder: (ctx, value, child) {
      return GridView(
          padding: EdgeInsets.all(15),
          children: value.Categories.map((e) => Text(e.categoryName)).toList(),
          gridDelegate: SliverGridDelegateWithMaxCrossAxisExtent(
            maxCrossAxisExtent: 200,
            childAspectRatio: 3 / 2,
            crossAxisSpacing: 20,
            mainAxisSpacing: 20,
          ));
    });
  }
}
