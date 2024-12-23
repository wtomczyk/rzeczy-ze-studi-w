package edu.lab03;

public class Main {

    public static void main(String[] args) {
	    CPerson person = new CPerson("aaa","bbb", 00230502532L);
        System.out.println(person.info());
        CEmployee employee = new CEmployee(person, 2.0, 200.0);
        System.out.println(employee.info());
        CPerson person2 = new CPerson(person);
        System.out.println(person2.info());
    }
}
