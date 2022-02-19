import 'package:flutter/material.dart';
import 'package:shopping_app/helpers/custom_input_decorations.dart';
import 'package:shopping_app/screens/login_screen.dart';

class RegisterScreen extends StatefulWidget {
  static const routerName = "/register";
  const RegisterScreen();

  @override
  _RegisterScreenState createState() => _RegisterScreenState();
}

class _RegisterScreenState extends State<RegisterScreen> {
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
          body: SingleChildScrollView(
        child: Container(
            margin: EdgeInsets.all(10),
            child: Form(
                child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                  SingleChildScrollView(
                      child: Column(
                    children: [
                      SizedBox(
                        height: 25,
                      ),
                      Container(
                        margin: EdgeInsets.only(left: 10, bottom: 25),
                        width: double.infinity,
                        child: Text(
                          "Sign Up",
                          textAlign: TextAlign.left,
                          style: TextStyle(
                              color: Theme.of(context).primaryColor,
                              fontSize: 35),
                        ),
                      ),
                      SizedBox(
                        height: 10,
                      ),
                      TextFormField(
                        decoration:
                            CustomInputDecoration.CustomeInputDecoration(
                                context, "UserName"),
                      ),
                      SizedBox(
                        height: 10,
                      ),
                      TextFormField(
                        decoration:
                            CustomInputDecoration.CustomeInputDecoration(
                                context, "Password"),
                        obscureText: true,
                      ),
                      SizedBox(
                        height: 10,
                      ),
                      TextFormField(
                        decoration:
                            CustomInputDecoration.CustomeInputDecoration(
                                context, "Email"),
                      ),
                      SizedBox(
                        height: 10,
                      ),
                      TextFormField(
                        decoration:
                            CustomInputDecoration.CustomeInputDecoration(
                                context, "Phone"),
                      ),
                      SizedBox(
                        height: 10,
                      ),
                      Container(
                          width: double.infinity,
                          child: ElevatedButton(
                              onPressed: () {}, child: Text("Sign Up"))),
                      Container(
                          width: double.infinity,
                          child: FlatButton(
                              onPressed: () {
                                Navigator.of(context).pushReplacementNamed(
                                    LoginScreen.routerName);
                              },
                              child: Text("Back to  Login"))),
                    ],
                  ))
                ]))),
      )),
    );
  }
}
