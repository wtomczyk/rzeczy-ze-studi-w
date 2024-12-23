package edu.lab05;

public class EParameterError extends IllegalArgumentException{
    private static int code = 20001;
    protected String pName;
    public EParameterError(String pName, String message){
        super(String.format("Error code: %d, parameter name: %s, Message: %s", code, pName, message));
        this.pName=pName;
    }
    public EParameterError(String pName, String message, Throwable cause){
        super(String.format("Error code: %d, parameter name: %s, Message: %s", code, pName, message), cause);
        this.pName=pName;
    }
}
