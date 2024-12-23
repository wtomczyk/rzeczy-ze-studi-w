package edu.lab03;

public class CPerson{
    protected String name;
    protected String familyName;
    protected Integer birthYear;
    protected Long pesel;
    public static String NATIONALITY = "PL";
    private static String KIND = "OSOBA";

    public CPerson() {

    }

    public CPerson(String name, String familyName, Integer birthYear, Long pesel) {
        this.name = name;
        this.familyName = familyName;
        this.birthYear = birthYear;
        this.pesel = pesel;
    }

    public CPerson(String name, String familyName, Long pesel) {
        this.name = name;
        this.familyName = familyName;
        this.pesel = pesel;

        Integer year = Math.toIntExact(pesel/1000000000L);
        year += ((Math.toIntExact((pesel % 1000000000L)/10000000L)<13) ? 1900 : 2000);
        setBirthYear(year);
    }

    public CPerson(CPerson person) {
        this.name = person.name;
        this.familyName = person.familyName;
        this.birthYear = person.birthYear;
        this.pesel = person.pesel;
    }

    @Override
    public String toString() {
        return "CPerson{" +
                "name='" + name + '\'' +
                ", familyName='" + familyName + '\'' +
                ", birthYear=" + birthYear +
                ", pesel=" + pesel +
                '}';
    }
    public String info(){
        return KIND + " " + name + " " + familyName + ", ur. w " + birthYear + ", PESEL "+ pesel;
    };
    public static String getKIND(){
        return KIND;
    };


    public String getName() {
        return name;
    }

    public String getFamilyName() {
        return familyName;
    }

    public Integer getBirthYear() {
        return birthYear;
    }
    public Long getPesel() {
        return pesel;
    }
    public static String getNATIONALITY() {
        return NATIONALITY;
    }


    public static void setNATIONALITY(String NATIONALITY) {
        CPerson.NATIONALITY = NATIONALITY;
    }

    public static void setKIND(String KIND) {
        CPerson.KIND = KIND;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setFamilyName(String familyName) {
        this.familyName = familyName;
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
}
