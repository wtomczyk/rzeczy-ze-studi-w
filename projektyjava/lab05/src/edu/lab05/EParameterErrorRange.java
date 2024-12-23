package edu.lab05;

public class EParameterErrorRange extends EParameterError{
    private static int code = 20003;
    public EParameterErrorRange(String pName, String message){
        super(pName, message);
    }
    public EParameterErrorRange(String pName, String message, Throwable cause){
        super(pName, message, cause);
    }
}
