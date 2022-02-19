import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:shopping_app/providers/category_provider.dart';
import 'package:shopping_app/screens/category_screen.dart';
import './screens/login_screen.dart';
import './screens/registation_screen.dart';
import './providers/auth_provider.dart';

void main() {
  runApp(HomePage());
}

class HomePage extends StatelessWidget {
  HomePage();

  @override
  Widget build(BuildContext context) {
    return MultiProvider(
        providers: [
          ChangeNotifierProvider(
            create: (ctx) => AuthProvider(),
          ),
          ChangeNotifierProxyProvider<AuthProvider, CategoryProvider>(
            create: (_) => new CategoryProvider(),
            update: (context, value, previous) => previous
              ..reciveToke(value.Token,
                  previous.Categories == null ? [] : previous.Categories),
          )
        ],
        child: Consumer<AuthProvider>(
          builder: (context, value, child) {
            return MaterialApp(
              debugShowCheckedModeBanner: false,
              home: value.isAuth ? CateogryScreen() : LoginScreen(),
              routes: {
                RegisterScreen.routerName: (ctx) => RegisterScreen(),
              },
            );
          },
        ));
  }
}
