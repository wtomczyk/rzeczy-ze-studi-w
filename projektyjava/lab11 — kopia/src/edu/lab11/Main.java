package edu.lab11;

import javax.swing.*;

public class Main {

    public static void main(String[] args) {
        SwingUtilities.invokeLater(()-> new CMainForm("Programowanie obiektowe - klasy generyczne").setVisible(true));
    }
}
