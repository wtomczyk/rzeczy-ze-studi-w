package edu.lab09;

import javax.swing.*;

public class Main {

    public static void main(String[] args) {
        SwingUtilities.invokeLater(()-> new CMainForm("kod").setVisible(true));
    }
}
