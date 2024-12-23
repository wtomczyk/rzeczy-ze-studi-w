package edu.lab05;
import java.io.IOException;
import java.util.logging.FileHandler;
import java.util.logging.Logger;
import java.util.logging.SimpleFormatter;
public class Main {
    private static CDataFile badReference = null;
    private static Logger logger = Logger.getLogger("aLogger");
    private static FileHandler fh;
    private static void assignLogger(){
        try{
            fh = new FileHandler("c\\temp\\mojLogger.log",true);
            logger.addHandler(fh);
            fh.setFormatter( new SimpleFormatter());
        }
        catch(SecurityException e ){
            e.printStackTrace();
        }
        catch (IOException e ){
            e.printStackTrace();
        }
    }
    private static void releaseLogger(){
        logger.removeHandler(fh);
    }
    public static void main(String[] args) {
	    assignLogger();
        try{
            CDataFile goodDataFile = new CDataFile("C:\\Users\\admin\\Desktop\\projektyjava\\lab05\\src\\resource\\file.dat");


            //wyjątek nullpointerexception
            //badReference.readFile();

            //wyjątek edatafilenotfound - checked, obsłużony
            //CDataFile badDataFile = new CDataFile("c:\\path-which-do-not-exist\\file.dat");

            //wyjątek eparametererror - checked obsłużony
            //CDataFile badDataFile = new CDataFile("C:\\Users\\admin\\Desktop\\projektyjava\\lab05\\src\\resource\\file-bad-header.dat");

            //próba odczytu złej wartości całkowitej
            CDataFile badDataFile = new CDataFile("C:\\Users\\admin\\Desktop\\projektyjava\\lab05\\src\\resource\\file-bad-int.dat");

            //wartość całkowita nie mieszcząca się w zakesie
            //CDataFile badDataFile = new CDataFile("C:\\Users\\admin\\Desktop\\projektyjava\\lab05\\src\\resource\\file-bad-range-int.dat");

            //zły double
            //CDataFile badDataFile = new CDataFile("C:\\Users\\admin\\Desktop\\projektyjava\\lab05\\src\\resource\\file-bad-double.dat");

            //zły footer
            //CDataFile badDataFile = new CDataFile(""C:\\Users\\admin\\Desktop\\projektyjava\\lab05\\src\\resource\\file-bad-footer.dat");

            //
            //
            
            goodDataFile.readFile();
            badDataFile.readFile();
        }
        catch(EDataFileNotFound|EDataFileIncorrectHeader|EDataFileIncorrectFooter|EParameterErrorRange ee){
            logger.info(ee.getMessage());
        }
        releaseLogger();
    }
}
