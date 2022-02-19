import 'package:flutter/material.dart';

class CustomInputDecoration {
  static InputDecoration CustomeInputDecoration(
      BuildContext context, String labelName) {
    return InputDecoration(
        labelText: labelName,
        focusedBorder: OutlineInputBorder(
          borderSide:
              BorderSide(color: Theme.of(context).primaryColor, width: 1.0),
        ),
        enabledBorder: OutlineInputBorder(
          borderSide:
              BorderSide(color: Theme.of(context).primaryColor, width: 1.0),
        ),
        errorBorder: OutlineInputBorder(
          borderSide:
              BorderSide(color: Theme.of(context).errorColor, width: 1.0),
        ));
  }
}

class InputValidation {
  static String InputIsRequired(String inputData) {
    if (inputData.isEmpty) {
      return "The Input is Required";
    } else {
      return null;
    }
  }
}
