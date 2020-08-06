if (maske.ToLower().Equals("FTPZieleUebersicht".ToLower()))
                {
                    frmFTPZiele ftpZiele = new frmFTPZiele();
                    TabHinzufuegen(ftpZiele);
                    ftpZiele.FormClosed += FormClosed;
                    return true;
                }