import 'package:flutter/material.dart';
import 'package:provider/provider.dart';
import 'package:shopping_app/helpers/custom_input_decorations.dart';
import 'package:shopping_app/http-exception/httpException.dart';
import 'package:shopping_app/models/login_user.dart';
import 'package:shopping_app/providers/auth_provider.dart';
import 'package:shopping_app/screens/registation_screen.dart';

class LoginScreen extends StatefulWidget {
  static const routerName = "/";
  LoginUser loginUser = LoginUser();
  LoginScreen();

  @override
  _LoginScreenState createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  final formState = GlobalKey<FormState>();

  Future<void> submitData() async {
    if (formState.currentState.validate()) {
      formState.currentState.save();
      try {
        await Provider.of<AuthProvider>(context, listen: false)
            .loginUser(widget.loginUser.userName, widget.loginUser.password);
      } on HttpExceptionUserNameAndPasswordIsWrong {
        showDialog(
            context: context,
            builder: (_) => AlertDialog(
                  title: Text("Authication"),
                  content: Text("userName or Password is Wrong"),
                  actions: [
                    ElevatedButton(
                      child: Text("Ok"),
                      onPressed: () => Navigator.of(context).pop(),
                    )
                  ],
                ));
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: SafeArea(
      child: Container(
        padding: EdgeInsets.all(10),
        child: Form(
          key: formState,
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Text(
                "Dimond Shop",
                style: TextStyle(color: Colors.blueAccent, fontSize: 25),
              ),
              SizedBox(
                height: 25,
              ),
              TextFormField(
                  decoration: CustomInputDecoration.CustomeInputDecoration(
                      context, "UserName"),
                  onSaved: (newValue) => widget.loginUser.userName = newValue,
                  validator: InputValidation.InputIsRequired),
              SizedBox(
                height: 25,
              ),
              TextFormField(
                decoration: CustomInputDecoration.CustomeInputDecoration(
                    context, "Password"),
                obscureText: true,
                onSaved: (newValue) => widget.loginUser.password = newValue,
                validator: InputValidation.InputIsRequired,
              ),
              SizedBox(
                height: 25,
              ),
              Container(
                  width: double.infinity,
                  child: ElevatedButton(
                      onPressed: () {
                        submitData();
                      },
                      child: Text("Login"))),
              Container(
                  width: double.infinity,
                  child: FlatButton(
                      onPressed: () {
                        Navigator.of(context)
                            .pushReplacementNamed(RegisterScreen.routerName);
                      },
                      child: Text("Sign Up")))
            ],
          ),
        ),
      ),
    ));
  }
}
