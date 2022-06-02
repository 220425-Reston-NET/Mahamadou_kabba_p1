//  this file will contain interface
// inface dicate what object can have
public interface IMenu
{
    // Display method will write the to the terminal the answer choices the user can pick
    // It will show what menu they are currently on
    void Display();

    // yourChoice method will grab the user feedback and return what menu should be displayed
    // string ourStore();
    string YourChoice();
}