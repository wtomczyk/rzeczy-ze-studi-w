package edu.lab11;

import generic.CMyLinkedList;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;

public class CMainForm extends javax.swing.JFrame{
    private JPanel mainPanel;
    private JButton strClear;
    private JTextField strTextField;
    private JList strList;
    private JButton strButton;
    private JTextField strFind;
    private JButton strFindId;
    private JButton strFindIndex;
    private JTextField strIdField;
    private JTextField intIdField;
    private JButton intButton;
    private JList intList;
    private JTextField intTextField;
    private JComboBox personYear;
    private JTextField personIdField;
    private JTextField personTextFname;
    private JTextField personTextName;
    private JButton personButton;
    private JList personList;
    private JButton imgButton;
    private JTextField imageIdField;
    private JList imgList;

    private final DefaultListModel<Object> modelStr;
    private final DefaultListModel<Object> modelInt;

    private final CMyLinkedList<Integer, String> myListStr;
    private final CMyLinkedList<Byte, Integer> myListInt;

    private final DefaultListModel<Object> modelPerson;
    private final DefaultListModel<Object> modelImg;

    private final CMyLinkedList<Long, CPerson> myListPerson;
    private final CMyLinkedList<Integer, ImageIcon> myListImg;

    public CMainForm(String title) throws HeadlessException {
        super(title);
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setContentPane(mainPanel);
        this.pack();
        this.setLocationRelativeTo(null);

        this.setResizable(false);
        this.setLocationRelativeTo(null);

        myListStr = new CMyLinkedList<>();
        myListInt = new CMyLinkedList<>();

        modelStr = new DefaultListModel<>();
        modelInt = new DefaultListModel<>();

        myListPerson = new CMyLinkedList<>();
        myListImg = new CMyLinkedList<>();

        modelPerson = new DefaultListModel<>();
        modelImg = new DefaultListModel<>();

        personList.setModel(modelPerson);
        imgList.setModel(modelImg);
        imgList.setCellRenderer(new CImgListRenderer(this.myListImg));
        strList.setModel(modelStr);
        intList.setModel(modelInt);

        strButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                strButtonClick();
            }
        });
        strClear.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                strButtonClearClick();
            }
        });
        strFindId.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                strGetByIdClick();
            }
        });
        strFindIndex.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                strGetByIndexClick();
            }
        });
        intButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                intButtonClick();
            }
        });
        personButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                personButtonClick();
            }
        });
        imgButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                imageButtonClick();
            }
        });
    }

    private void personButtonClick(){
        try {
            Long n = Long.parseLong(personIdField.getText());
            CPerson person = new CPerson(
                    personTextFname.getText(),
                    personTextName.getText(),
                    Integer.parseInt(personYear.getItemAt(
                            personYear.getSelectedIndex()
                    ).toString())
            );
            if(personTextFname.getText().compareTo("")!=0 && personTextName.getText().compareTo("")!=0){
                myListPerson.add(n, person);
            }
            else{
                JOptionPane.showMessageDialog(this,"Któraś z wartości jest pusta");
            }


            myListPerson.printToList(modelPerson);
        }catch(NumberFormatException e){
            JOptionPane.showMessageDialog(this,"Niepoprawna wartość. Komunikat: "+e.getMessage());
        }catch (IllegalArgumentException e){
            JOptionPane.showMessageDialog(this,e.getMessage());
        }
    }

    private void imageButtonClick(){
        try {
            Integer n = Integer.parseInt((imageIdField.getText()));
            JFileChooser fc = new JFileChooser();
            fc.setCurrentDirectory(new File("."));
            int returnVal = fc.showOpenDialog(this);
            if (returnVal == JFileChooser.APPROVE_OPTION) {
                myListImg.add(n,
                        new ImageIcon(fc.getSelectedFile().getAbsolutePath()));
                myListImg.printToList(modelImg);
            }
        }catch(NumberFormatException e){
            JOptionPane.showMessageDialog(this,"Niepoprawna wartość. Komunikat: "+e.getMessage());
        }catch (IllegalArgumentException e){
            JOptionPane.showMessageDialog(this,e.getMessage());
        }
    }
    private void strButtonClick(){
        try{
            Integer n = Integer.parseInt(strIdField.getText());
            String text = strTextField.getText().trim();
            if(text.compareTo("")!=0){
                myListStr.add(n,text);
            }
            myListStr.printToList(modelStr);
        }catch (NumberFormatException e){
            JOptionPane.showMessageDialog(this,"Niepoprawna wartość. Komunikat: "+e.getMessage());
        }catch (IllegalArgumentException e){
            JOptionPane.showMessageDialog(this,e.getMessage());
        }
    }
    private void strButtonClearClick(){
        myListStr.clear();
        myListStr.printToList(modelStr);
    }
    private void strGetByIndexClick(){
        try{
            int idx = Integer.parseInt(strFind.getText());
            try{
                String s = myListStr.getByIndex(idx);
                JOptionPane.showMessageDialog(this,"Zwrócona wartość: " + s);
            }catch (IndexOutOfBoundsException e){
                JOptionPane.showMessageDialog(this,"Brak elementu o indeksie = " + idx);
            }
        }catch (NumberFormatException e){
            JOptionPane.showMessageDialog(this,"Niepoprawna wartość. Komunikat: "+e.getMessage());
        }catch (IllegalArgumentException e){
            JOptionPane.showMessageDialog(this,e.getMessage());
        }
    }
    private void strGetByIdClick(){
        try{
            int id = Integer.parseInt(strFind.getText());
            String s = myListStr.getById(id);
            if(s!=null){
                JOptionPane.showMessageDialog(this,"Zwrócona wartość: " +s);
            }else{
                JOptionPane.showMessageDialog(this,"Brak elementu o id = " + id);
            }
        }catch (NumberFormatException e){
            JOptionPane.showMessageDialog(this,"Niepoprawna wartość. Komunikat: "+e.getMessage());
        }catch (IllegalArgumentException e){
            JOptionPane.showMessageDialog(this,e.getMessage());
        }

    }
    private void intButtonClick(){
        try{
            Byte d = Byte.parseByte(intIdField.getText());
            Integer v = Integer.parseInt(intTextField.getText());
            myListInt.add(d,v);
            myListInt.printToList(modelInt);
        }catch(NumberFormatException e){
            JOptionPane.showMessageDialog(this,"Niepoprawna wartość. Komunikat: "+e.getMessage());
        }catch (IllegalArgumentException e){
            JOptionPane.showMessageDialog(this,e.getMessage());
        }

    }

    private void createUIComponents() {
        // TODO: place custom component creation code here
    }
}
