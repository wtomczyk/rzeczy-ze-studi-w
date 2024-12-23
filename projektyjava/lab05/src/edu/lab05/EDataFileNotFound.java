package edu.lab05;

public class EDataFileNotFound extends java.io.FileNotFoundException{
    private static int code = 10001;
    public EDataFileNotFound(String message){super(String.format("Error code: %d. Message: %s", code, message));}
}
