using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Contract;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client
{
    class ViewModel: INotifyPropertyChanged
    {
        NetClient network;
        public string _myMessege;
        public string _NickName;
        public LoginColor _SelectedString;
        public string _buttonSave;
        public string stringCreateGroup { get; set; }
        public SMS dataSmsFile;
        public string _ButtonCreate;

        public string _ButtonCreateVisible
        {
            get
            {
                if (_ButtonCreate == null)
                {
                    _ButtonCreate = "Hidden";
                }
                return _ButtonCreate;
            }
            set
            {
                _ButtonCreate = value;
                OnNotifyPropertyChanged("_ButtonCreateVisible");
            }
        }


        public SMS SelectedSms
        {
            get
            {


                if (dataSmsFile == null)
                {
                    dataSmsFile = new SMS();
                }


                return dataSmsFile;
            }
            set
            {

                dataSmsFile = value;
              
                ButtonVisibleAndSsave(dataSmsFile);
                OnNotifyPropertyChanged("SelectedSms");
            }
        }

        public void ButtonVisibleAndSsave(SMS dataSmsFile)
        {
            ButtonSave = "Hidden";
            if ( dataSmsFile.filetrue == true)
            {              
                ButtonSave = "Visible";
            }
        }
        public ViewModel()
        {
                network = new NetClient();
				StringsUsers = network.Data;
				
				
		}

        public string ButtonSave
        {
            get
            {
                if (_buttonSave == null)
                {
                    _buttonSave = "Hidden";
                }
                return _buttonSave; 
            }
            set
            {
                _buttonSave = value;
                OnNotifyPropertyChanged("ButtonSave");
            }
        }

        public LoginColor SelectedString
        {
            get
            {
                if (_SelectedString == null)
                {
                    _SelectedString = new LoginColor();
                }
                return _SelectedString; ;
            }
            set
            {
                _SelectedString = value;
                OnNotifyPropertyChanged("SelectedString");
            }
        }

        public string people2;
        public string group2;

        public string StringGroupText
        {
            get
            {
                if (group2 == null)
                {
                    group2 = String.Empty;
                }
                return group2; 
            }
            set
            {
                group2 = value;
                OnNotifyPropertyChanged("StringGroupText");
            }
        }

        public string StringPeopleText
        {
            get
            {
                if (people2 == null)
                {
                    people2 = String.Empty;
                }
                return people2; ;
            }
            set
            {
                people2 = value;
                OnNotifyPropertyChanged("StringPeopleText");
            }
        }

        public string NICKNAME
        {
            get
            {
                if (_NickName == null)
                {
                    _NickName = String.Empty;
                }
                return _NickName; ;
            }
            set
            {
                _NickName = value;
                OnNotifyPropertyChanged("NICKNAME");
            }
        }

        public string _ListHidden;

        public string LISTHIDDEN
        {
            get
            {
                if (_ListHidden == null)
                {
                    _ListHidden = "Visible";
                }
                return _ListHidden; 
            }
            set
            {
                _ListHidden = value;
                OnNotifyPropertyChanged("LISTHIDDEN");
            }
        }


        public string Text
        {
            get
            {
                if(_myMessege == null)
                {
                    _myMessege = String.Empty;
                }
                return _myMessege; ;
            }
            set
            {
                _myMessege = value;
                OnNotifyPropertyChanged("Text");
            }
        }

        ObservableCollection<SMS> _messege;
        public ObservableCollection<SMS> MessegeChat
        {
            get
            {
                if (_messege == null)
                    _messege = new ObservableCollection<SMS>();
                
                return _messege; 
            }
            set
            {

                _messege = value;
                OnNotifyPropertyChanged("MessegeChat");

            }
        }


        ObservableCollection<LoginColor> _users;
        public ObservableCollection<LoginColor> StringsUsers
         {
            get
            {
				if (_users == null)
					_users = new ObservableCollection<LoginColor>();

				return _users;
            }
            set
            {
                
                _users = value;
                OnNotifyPropertyChanged("StringsUsers");
               
            }
        }

        ObservableCollection<LoginColor> _group;
        public ObservableCollection<LoginColor> Group
        {
            get
            {
                if (_group == null)
                    _group = new ObservableCollection<LoginColor>();

                return _group;
            }
            set
            {

                _group = value;
                OnNotifyPropertyChanged("Group");

            }
        }

        
        ObservableCollection<LoginColor> _people;
        public ObservableCollection<LoginColor> People
        {
            get
            {
                if (_people == null)
                    _people = new ObservableCollection<LoginColor>();

                return _people;
            }
            set
            {

                _people = value;
                OnNotifyPropertyChanged("People");

            }
        }



        public LoginColor _grouppa;
        public LoginColor _peoples;
        public _Image _smiles;


        public _Image SMILES
        {
            get
            {
                if (_smiles == null)
                {
                    _smiles = new _Image();
                }
                return _smiles;
            }
            set
            {
                _smiles = value;
                OnNotifyPropertyChanged("SMILES");
            }
        }

        public LoginColor _GROUP
        {
            get
            {
                if (_grouppa == null)
                {
                    _grouppa = new LoginColor();
                }
                return _grouppa;
            }
            set
            {
                _grouppa = value;
                OnNotifyPropertyChanged("_GROUP");
            }
        }

        public LoginColor _PEOPLE
        {
            get
            {
                if (_peoples == null)
                {
                    _peoples = new LoginColor();
                }
                return _peoples;
            }
            set
            {
                _peoples = value;
                OnNotifyPropertyChanged("_PEOPLE");
            }
        }




        public string _login;
        public string _password;
        public string _visible;
        public string _eror;

        public string _EROR
        {
            get
            {
                if (_eror == null)
                {
                    _eror = String.Empty;
                }
                return _eror;
            }
            set
            {
                _eror = value;
                OnNotifyPropertyChanged("_EROR");
            }
        }

        public string _Visible
        {
            get
            {
                if (_visible == null)
                {
                    _visible = "Visible";
                }
                return _visible;
            }
            set
            {
                _visible = value;
                OnNotifyPropertyChanged("_Visible");
            }
        }

        public string _Login
        {
            get
            {
                if (_login == null)
                {
                    _login = String.Empty;
                }
                return _login;
            }
            set
            {
                _login = value;
                OnNotifyPropertyChanged("_Login");
            }
        }

        public string _Password
        {
            get
            {
                if (_password == null)
                {
                    _password = String.Empty;
                }
                return _password;
            }
            set
            {
                _password = value;
                OnNotifyPropertyChanged("_Password");
            }
        }



        /// <summary>
        /// Background Главного Окна
        /// </summary>
        public string Backgroundwindow;
        /// <summary>
        /// Кнопка фона для Открытия Файлов
        /// </summary>
        public string buttonOpenBackground;
        /// <summary>
        ///  Кнопка фона для отправки Файлов
        /// </summary>
        public string buttonSendBackground;
        /// <summary>
        /// Кнопка фона для отправки Смайлов
        /// </summary>
        public string buttonSmileBackground;
        public string backroundLogin;

        public string backroundExit;

        public string backroundRegister;
        public string ButtonSmileBackground
        {
            get
            {
                if (buttonSmileBackground == null)
                {
                    string path = Directory.GetCurrentDirectory();
                    path = Directory.GetParent(path).ToString();
                    path = Directory.GetParent(path).ToString();
                    path = path + @"\Images\smile.gif";
                    buttonSmileBackground = path;
                }
                return buttonSmileBackground;
            }
            set
            {
                buttonSmileBackground = value;
                OnNotifyPropertyChanged("ButtonSmileBackground");
            }
        }

        
        public string ButtonOpenBackground
        {
            get
            {
                if (buttonOpenBackground == null)
                {
                    string path = Directory.GetCurrentDirectory();
                    path = Directory.GetParent(path).ToString();
                    path = Directory.GetParent(path).ToString();
                    path = path + @"\Images\open.png";
                    buttonOpenBackground = path;
                }
                return buttonOpenBackground;
            }
            set
            {
                Backgroundwindow = value;
                OnNotifyPropertyChanged("ButtonOpenBackground");
            }
        }

        public string ButtonSendBackground
        {
            get
            {
                if (buttonSendBackground == null)
                {
                    string path = Directory.GetCurrentDirectory();
                    path = Directory.GetParent(path).ToString();
                    path = Directory.GetParent(path).ToString();
                    path = path + @"\Images\Send.png";
                    buttonSendBackground = path;
                }
                return buttonSendBackground;
            }
            set
            {
                buttonSendBackground = value;
                OnNotifyPropertyChanged("ButtonSendBackground");
            }
        }

        public string BackgroundWindow
        {
            get
            {
                if(Backgroundwindow == null)
                {
                    string path = Directory.GetCurrentDirectory();                
                    path = Directory.GetParent(path).ToString();
                    path = Directory.GetParent(path).ToString();
                    path = path+ @"\Images\ImageBackgroudWindow.jpg";
                    BackgroundWindow = path;
                }       
                return Backgroundwindow;
            }
            set
            {
                Backgroundwindow = value;
                OnNotifyPropertyChanged("BackgroundWindow");
            }
        }

        

        public string BackroundLogin
        {
            get
            {
                if (backroundLogin == null)
                {
                    string path = Directory.GetCurrentDirectory();
                    path = Directory.GetParent(path).ToString();
                    path = Directory.GetParent(path).ToString();
                    path = path + @"\Images\LOGIN.png";
                    backroundLogin = path;
                }
                return backroundLogin;
            }
            set
            {
                backroundLogin = value;
                OnNotifyPropertyChanged("BackroundLogin");
            }
        }

        public string BackroundExit
        {
            get
            {
                if (backroundExit == null)
                {
                    string path = Directory.GetCurrentDirectory();
                    path = Directory.GetParent(path).ToString();
                    path = Directory.GetParent(path).ToString();
                    path = path + @"\Images\Exit.jpg";
                    backroundExit = path;
                }
                return backroundExit;
            }
            set
            {
                backroundExit = value;
                OnNotifyPropertyChanged("BackroundExit");
            }
        }

        public string BackroundRegister
        {
            get
            {
                if (backroundRegister == null)
                {
                    string path = Directory.GetCurrentDirectory();
                    path = Directory.GetParent(path).ToString();
                    path = Directory.GetParent(path).ToString();
                    path = path + @"\Images\Register.png";
                    backroundRegister = path;
                }
                return backroundRegister;
            }
            set
            {
                backroundRegister = value;
                OnNotifyPropertyChanged("BackroundRegister");
            }
        }
        


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged([CallerMemberName]string name = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        RelayCommand _log_in;
        RelayCommand _Exit;
        RelayCommand _exitButton;
        RelayCommand _Register;
        RelayCommand _sendMessege;
        RelayCommand _InterlocutorChoice;
        RelayCommand _SendFile;
        RelayCommand _SaveFile;
        RelayCommand _Create_New_Group;
        RelayCommand _Create_new_Group2;
        RelayCommand _AddPersonInroup;
        RelayCommand _GroupChoice;
        RelayCommand _PeopleChoice;
        RelayCommand _okgr;
        RelayCommand _cancelgr;
        RelayCommand _DeleteGroup;
        RelayCommand _Smile;
        RelayCommand _Smile2;

        public string SmileVisible;

        public string SMILEVISIBLE
        {
            get
            {
                if (SmileVisible == null)
                {
                    SMILEVISIBLE = "Hidden";
                }
                return SmileVisible;
            }
            set
            {
                SmileVisible = value;
                OnNotifyPropertyChanged("SMILEVISIBLE");
            }
        }

        public ICommand SMILE2
        {
            get
            {
                if (_Smile2 == null)
                    _Smile2 = new RelayCommand(Func__Smile2);
                return _Smile2;
            }
        }

        public void Func__Smile2(object o)
        {          
            SMILEVISIBLE = "Hidden";
            string group = "Group:";
            byte[] b = new byte[0];
            if (String.Empty != NICKNAME)
            {
                if (NICKNAME.Contains(group))
                {
                   
                }
                else
                {

                    network.AddMyMessege(Text, NICKNAME, SMILES.Way);
                    _messege.Add(new SMS() { Date = DateTime.Now, Login = NICKNAME, kLogin = _Login, file = b, Message = "", Way = SMILES.Way, fileName = "", filetrue = false, NameGroup = "" });
                    network.SendSMILE("", NICKNAME, _login, "", b, false, SMILES.Name);

                }
            }


        }

        public ICommand SMILE
        {
            get
            {
                if (_Smile == null)
                    _Smile = new RelayCommand(Func__Smile);
                return _Smile;
            }
        }

       

        
        ObservableCollection<_Image> _strings;
        public ObservableCollection<_Image> Strings
        {
            get
            {
                if (_strings == null)
                    _strings = FillingInSmile.StringRepository.GetStrings();
                
                return _strings;
            }
            set
            {

                _strings = value;
                OnNotifyPropertyChanged("Strings");

            }
        }

        public void Func__Smile(object o)
        {
            SMILEVISIBLE = "Visible";
            Console.WriteLine("");
        }

        public ICommand DELETEGROUP
        {
            get
            {
                if (_DeleteGroup == null)
                    _DeleteGroup = new RelayCommand(Func__deleteGroupMe);
                return _DeleteGroup;
            }
        }
        public void Func__deleteGroupMe(object o )
        {
            string group = "Group:";       
            if (NICKNAME.Contains(group))
            {
                _messege.Clear();
                network.SendDeleteGroup(NICKNAME);
            }
        }

        public ICommand OKGR
        {
            get
            {
                if (_okgr == null)
                    _okgr = new RelayCommand(Func__okgr);
                return _okgr;
            }
        }

        public ICommand CANCELGR
        {
            get
            {
                if (_cancelgr == null)
                    _cancelgr = new RelayCommand(Func__cancelrg);
                return _cancelgr;
            }
        }

        public void Func__cancelrg(object o)
        {
            LISTHIDDEN = "Visible";
        }


        public void Func__okgr(object o)
        {
            LISTHIDDEN = "Visible";
            //StringPeopleText;
            //StringGroupText;
            network.SendAddPeopleGroup(StringGroupText, StringPeopleText);
            
        }


        public ICommand GROUPCHOISE
        {
            get
            {
                if (_GroupChoice == null)
                    _GroupChoice = new RelayCommand(Func_GroupChoice);
                return _GroupChoice;
            }
        }

        public ICommand PEOPLECHOISE
        {
            get
            {
                if (_PeopleChoice == null)
                    _PeopleChoice = new RelayCommand(Func_PeopleChoice);
                return _PeopleChoice;
            }
        }

        public void Func_PeopleChoice(object o)
        {
            
            StringPeopleText = _PEOPLE.Login;
        }


        public void Func_GroupChoice(object o)
        {
            StringGroupText = _GROUP.Login;
            //StringPeopleText = _PEOPLE.Login;
        }

        public ICommand ADDPERSONINGROUP
        {
            get
            {
                if (_AddPersonInroup == null)
                    _AddPersonInroup = new RelayCommand(FuncCreateAddGroup);
                return _AddPersonInroup;
            }
        }

        public void FuncCreateAddGroup(object o)
        {
            LISTHIDDEN = "Hidden";
            string group = "Group:";
            ObservableCollection<LoginColor> tmp = new ObservableCollection<LoginColor>();
            ObservableCollection<LoginColor> tmp2 = new ObservableCollection<LoginColor>();

            foreach (var i in _users)
            {
                if(i.Login.Contains(group))
                {
                    tmp.Add(i);
                }
                else
                {
                    tmp2.Add(i);
                }
            }

            Group = tmp;
            People = tmp2;
        }


        public ICommand CREATEGROUP
        {
            get
            {
                if (_Create_new_Group2 == null)
                    _Create_new_Group2 = new RelayCommand(FuncCreateGroup2);
                return _Create_new_Group2;
            }
        }

        public void FuncCreateGroup2(object o)
        {
            
            _ButtonCreateVisible = "Visible";

        }


        public ICommand CREATEGROUPOK
        {
            get
            {
                if (_Create_New_Group == null)
                    _Create_New_Group = new RelayCommand(FuncCreateGroup);
                return _Create_New_Group;
            }
        }

        public void FuncCreateGroup(object o)
        {        
            string tmp = "Group: " + stringCreateGroup;
            network.SendCreateNewGroup(tmp);
            _ButtonCreateVisible = "Hidden";
        }


        public ICommand LOGIN
        {
            get
            {
                if (_log_in == null)
                    _log_in = new RelayCommand(FuncLogIn);
                return _log_in;
            }
        }

        public ICommand InterlocutorChoice
        {
            get
            {
                if (_InterlocutorChoice == null)
                    _InterlocutorChoice = new RelayCommand(InterlocutorChoiceFunc);
                return _InterlocutorChoice;
            }
        }

        public void InterlocutorChoiceFunc(object o)
        {
            string gr = "Group:";
            NICKNAME = _SelectedString.Login;
            if (NICKNAME.Contains(gr))
            {
               
                MessegeChat = network.CLIENTGROUP(NICKNAME);
                StringsUsers = network.ChangeColorNickName(NICKNAME);
            }
            else
            {
                MessegeChat = network.CLIENT(NICKNAME);
                StringsUsers = network.ChangeColorNickName(NICKNAME);
            }
        }
		public ICommand Register
        {
            get
            {
                if (_Register == null)
                    _Register = new RelayCommand(RegisterNewPerson);
                return _Register;
            }
        }

        public void RegisterNewPerson(object o)
        {
            //foreach (var i in network.GetPositionPerson())
            //{
            //    if (_Login == i.name )
            //    {
            //        _EROR = "THIS NAME ALREADY EXISTS";
            //    }
            //    else
            //    {
            //        network.AddNewPerson(new Contract.Login { name = _Login, Password = _Password });
            //    }
            //}
           
        }

        public ICommand _EXITBUTTON1
        {
            get
            {
                if (_exitButton == null)
                    _exitButton = new RelayCommand(FuncExit);
                return _exitButton;
            }
        }

        public ICommand SendMessege
        {

            get
            {
                if (_sendMessege == null)
                    _sendMessege = new RelayCommand(SendMessegeFunc);
                return _sendMessege; 
            }
        }

        public ICommand SendFile
        {

            get
            {
                if (_SendFile == null)
                    _SendFile = new RelayCommand(SendFileFunc);
                return _SendFile;
            }
        }
        public void SendFileFunc(object o)
        {
            string gruop = "Group:";
            if (NICKNAME.Contains(gruop)==false)
            {
                if (String.Empty != NICKNAME)
                {
                    OpenFileDialog frm = new OpenFileDialog();
                    frm.Filter = "Text Doc (*.txt) |*.txt| All Files (*.*)|*.*| HTML (*.html)|*.html";
                    frm.FilterIndex = 2;
                    frm.InitialDirectory = "D:\\";
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream fstream = File.OpenRead(frm.FileName))
                        {
                            byte[] files = new byte[fstream.Length];
                            fstream.Read(files, 0, files.Length);
                            _messege.Add(new SMS() { Login = NICKNAME, kLogin = "Я", Date = DateTime.Now, Message = "FILE SEND", file = files, fileName = Path.GetFileName(frm.FileName), filetrue = true });
                            network.AddMyMessege(NICKNAME, "FILE SEND", "");
                            network.SendMessage("FILE SEND", NICKNAME, _login, Path.GetFileName(frm.FileName), files, true);
                            Text = String.Empty;
                        }
                    }
                    else
                    {

                        ButtonSave = "Hidden";
                    }
                }       
            }
            else
            {
                MessageBox.Show("ОТПРАВИТЬ ФАЙЛ ГРУППЕ НЕ ДОСТУПНО");
            }
        }
        public ICommand SaveFile
        {

            get
            {
                if (_SaveFile == null)
                    _SaveFile = new RelayCommand(SaveFileFunc);
                return _SaveFile;
            }
        }

        public void SaveFileFunc(object o)
        {      
            SaveFileDialog frm = new SaveFileDialog();
            frm.FileName = dataSmsFile.fileName;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fstream = new FileStream(frm.FileName, FileMode.OpenOrCreate))
                {
                    fstream.Write(dataSmsFile.file, 0, dataSmsFile.file.Length);
                }
                ButtonSave = "Hidden";
            }
            else
            {
                ButtonSave = "Hidden";
            }

        }

        public void SendMessegeFunc(object o)
        {
            
            string group = "Group:";
            if (String.Empty != NICKNAME)
            {
                if (NICKNAME.Contains(group))
                {
                    byte[] b = new byte[0];
                    _messege.Add(new SMS() { Login = NICKNAME, kLogin = "Я", Date = DateTime.Now, Message = Text });
                    network.AddMyMessege(NICKNAME, Text,"");
                    network.SendMessageGroup(Text, _login,NICKNAME, "", b, false);
                    Text = String.Empty;
                }
                else
                {              
                    byte[] b = new byte[0];
                    _messege.Add(new SMS() { Login = NICKNAME, kLogin = "Я", Date = DateTime.Now, Message = Text });
                    network.AddMyMessege(NICKNAME, Text,"");
                    network.SendMessage(Text, NICKNAME, _login, "", b, false);
                    Text = String.Empty;
                }
            }

        }

        


        public void FuncExit(object o)
        {
            
        }

        public void FuncLogIn(object o)
        {
           
            if (network.Authentification(_Login)==true)
            {
                    _Visible = "Hidden";
                    network.MyLogin = _Login;
                    network.UpdateUsers(_Login);
            }
            else
            {
                _EROR = "WRONG LOGIN OR PASSWORD OR REGISTER";

            }
           
        }

        public ICommand WindowClosing
        {
            
            get
            {
                if (_Exit == null)
                    _Exit = new RelayCommand(ExitWindow);
                return _Exit;
            }
        }

        public void ExitWindow(object o)
        {   

            network.Exit();
        }


    }
}
