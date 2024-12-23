package edu.lab09;


import edu.shapes.*;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class CMainForm extends javax.swing.JFrame {
    private JPanel mainPanel;
    private JPanel graphicArea;
    private CDocument document;

    public CMainForm(String title) throws HeadlessException {
        super(title);
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setResizable(false);
        this.setContentPane(mainPanel);
        this.setLocationRelativeTo(null);
        this.pack();

        graphicArea.addMouseListener(new MouseAdapter() {
            @Override
            public void mousePressed(MouseEvent e) {
                super.mousePressed(e);
                graphicAreaMousePressed(e);
            }

            @Override
            public void mouseReleased(MouseEvent e) {
                super.mouseReleased(e);
                graphicAreaMouseReleased();
            }
        });
        graphicArea.addMouseMotionListener(new MouseMotionAdapter() {
            @Override
            public void mouseDragged(MouseEvent e) {
                super.mouseDragged(e);
                graphicAreaMouseDragged(e);
            }
        });
        document = new CDocument((CGraphicArea)graphicArea );
        document.addShape(new CShapeCircle(200,200,Color.lightGray,Color.BLACK,70));
        document.addShape(new CShapeCircle(600,300,Color.YELLOW,Color.BLUE,90));
        document.addShape(new CPolyRTriangle(500,600,Color.yellow,Color.BLUE,200,150));
        document.addShape(new CPolyRTriangle(800,400,Color.gray,Color.DARK_GRAY,250,100));
        document.addShape(new CKatownik(100,200,Color.RED,Color.BLUE,300,300,50));
        document.addShape(new CZetownik(200,50,Color.GRAY,Color.GREEN,100,10,150));
        document.addShape(new CCeownik(400,50,Color.GRAY,Color.GREEN,100,10,150));
        document.addShape(new CTeownik(600,50,Color.GRAY,Color.GREEN,100,10,150));
        document.addShape(new CDwuteownik(800,50,Color.GRAY,Color.GREEN,100,10,150));
        document.redraw();
    }
    private void createUIComponents() {
        graphicArea = new CGraphicArea();

    }
    private void graphicAreaMousePressed(MouseEvent evt){
        if(evt.getButton()==MouseEvent.BUTTON1){
            if(document.selectShape(evt.getX(), evt.getY()))
                document.redraw();
        }
    }
    private void graphicAreaMouseReleased(){
        document.deselectShape();
        document.redraw();
    }
    private void graphicAreaMouseDragged(MouseEvent evt){
        document.moveSelectedTo(evt.getX(),evt.getY());
        long time = document.redraw();
        if(time>0)
            setTitle(String.format("Kształtowniki, czas rysowania %d ms", time));
    }
}
