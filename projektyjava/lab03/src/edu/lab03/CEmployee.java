package edu.lab03;

public class CEmployee extends CPerson{
    protected Double empRate;
    protected Double salary;
    protected String name;
    protected String familyName;
    protected Integer birthYear;
    protected Long pesel;
    public static String NATIONALITY = "PL";
    private static String KIND = "PRACOWNIK";

    public String employeeReport(){
        return name + " " + familyName + " wymiar etatu " + empRate + " pensja " + salary;
    };
    public static String getKIND(){
        return KIND;
    }

    public CEmployee() {

    }
    public CEmployee(CEmployee employee) {
        this.empRate = employee.empRate;
        this.salary = employee.salary;
        this.name=employee.name;
        this.familyName = employee.familyName;
        this.birthYear = employee.birthYear;
        this.pesel = employee.pesel;
    }
    public CEmployee(CPerson person, Double empRate, Double salary) {
        this.name = person.name;
        this.familyName = person.familyName;
        this.pesel = person.pesel;
        this.birthYear = person.birthYear;
        this.empRate = empRate;
        this.salary = salary;
    }
    public CEmployee(String name, String familyName, Long pesel, Double empRate, Double salary) {
        super(name,familyName,pesel);
        //this.name = name;
        //this.familyName = familyName;
        //this.pesel = pesel;
        this.empRate = empRate;
        this.salary = salary;

        Integer year = Math.toIntExact(pesel/1000000000L);
        year += ((Math.toIntExact((pesel % 1000000000L)/10000000L)<13) ? 1900 : 2000);
        setBirthYear(year);
    }
    public String info(){
        return name + "\' " +
                KIND + " wymiar etatu: " + empRate + ", pensja: " + salary;
    };



    public Double getEmpRate() {
        return empRate;
    }

    public void setEmpRate(Double empRate) {
        this.empRate = empRate;
    }

    public Double getSalary() {
        return salary;
    }

    public void setSalary(Double salary) {
        this.salary = salary;
    }

    public static void setKIND(String KIND) {
        CEmployee.KIND = KIND;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getFamilyName() {
        return familyName;
    }

    public void setFamilyName(String familyName) {
        this.familyName = familyName;
    }

    public Integer getBirthYear() {
        return birthYear;
    }

    public void setPesel(Long pesel) {
        if((pesel < 210000000L) || (pesel > 99999999999L))
            throw new IllegalArgumentException("Niepoprawny pesel");
        this.pesel = pesel;
    }

    private void setBirthYear(Integer birthYear) {
        if((birthYear < 0) || (birthYear > 9999))
            throw new IllegalArgumentException("Niepoprawny rok urodzenia");
        this.birthYear = birthYear;
    }

    public Long getPesel() {
        return pesel;
    }

    public static String getNATIONALITY() {
        return NATIONALITY;
    }

    public static void setNATIONALITY(String NATIONALITY) {
        CEmployee.NATIONALITY = NATIONALITY;
    }

    @Override
    public String toString() {
        return "CEmployee{" +
                "empRate=" + empRate +
                ", salary=" + salary +
                ", name='" + name + '\'' +
                ", familyName='" + familyName + '\'' +
                ", birthYear=" + birthYear +
                ", pesel=" + pesel +
                '}';
    }
}
