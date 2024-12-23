package edu.shapes;

import java.awt.*;

public class CDwuteownik extends CPoly{
    protected int A;
    protected int G;
    protected int H;
    public CDwuteownik(int x0, int y0, Color f, Color b, int a, int g, int h){
        super(x0,y0,f,b,12);
        this.A=a;
        this.G=g;
        this.H=h;
    }
    @Override
    protected void updateCoordinates() {
        px[0]=X0;py[0]=Y0;
        px[1]=X0+A;py[1]=Y0;
        px[2]=X0+A;py[2]=Y0+G;
        px[3]=X0+(A)/2+G/2;py[3]=Y0+G;
        px[4]=X0+(A)/2+G/2;py[4]=Y0+H-G;
        px[5]=X0+A;py[5]=Y0+H-G;
        px[6]=X0+A;py[6]=Y0+H;
        px[7]=X0;py[7]=Y0+H;
        px[8]=X0;py[8]=Y0+H-G;
        px[9]=X0+(A)/2-G/2;py[9]=Y0+H-G;
        px[10]=X0+(A)/2-G/2;py[10]=Y0+G;
        px[11]=X0;py[11]=Y0+G;
    }
}
