   M S B A M L   `   `   `  ����C  ?Trabalho, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Trabalho.ViewsTrabalho.Views  5   	        Trabalho.Views.AbrirTarefa   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Trabalho.Views     5   	     � Title$  AbrirTarefa��5   	   $	��450��6   $	��800��6*   ���#D8D8D9.��5
      � .+�5   
   �� -   5         ��Name$ cbNivelDeImportancia��5      $
��Left=�61   $��36��6L   $��300,293,0,0q�6X   $	��Top=�6m   $	��176��6�   {�.  .@�5      �� $��Prioritária��6   �� 5      $��
Importante��6   �� 5      $��Normal��6   �� 5      $��Pouco Importante��6   5      �� 5   
   $��Nível de Importância:��6   $��Center=�60   $��26��6M   $��	0,261,0,0q�6Y   $	��Top=�6l   $	��216��6�   $��16(�5      $��Copperplate Gothic Bold)�5      ���#2D74E65      �� 5   
   -   5         ��Name$ 	txtTitulo��5      $
��Left=�6%   $��20��6@   $��152,152,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $	��175��6�   {�.  6�   �� 5   
   $��Título:��6   $
��Left=�6"   $��30��6=   $��
63,147,0,0q�6I   $	��Top=�6]   $��70��6u   $��16(�5      $��Copperplate Gothic Bold)�5      ���#2D74E65      �� 5   
   $��TAREFA��6   $��Center=�6!   $��40��6>   $��0,10,0,0q�6J   $	��Top=�6\   $	��158��6t   $��Britannic Bold)�5      $��30(�5      
����  �5      �� 5   
   $��Adicionar Alerta:��6   $
��Left=�6,   $��24��6G   $��
52,261,0,0q�6S   $	��Top=�6g   $	��175��6   $��16(�5      $��Copperplate Gothic Bold)�5       ���#2D74E65!      �� 5"   
   $��Repetir:��6   $
��Left=�6#   $��24��6>   $��586,261,0,0q�6J   $	��Top=�6_   $	��174��6w   $��16(�5#      $��Copperplate Gothic Bold)�5$      ���#2D74E65%      �� 5&   
   -   5        $ 	cbRepetir��5&      $
��Left=�6&   $��36��6A   $��546,293,0,0q�6M   $	��Top=�6b   $	��175��6z   {�.  .@�5'      �� $��Diário��6   �� 5(      $��Semanal��6   5)      �� 5*   
   $��	Data Fim:��6   $
��Left=�6$   $��30��6?   $��421,136,0,0q�6K   $	��Top=�6`   $	��100��6x   $��16(�5+      $��Copperplate Gothic Bold)�5,      ���#2D74E65-      (  "System.Windows.Controls.DatePicker  5.   
   -   5          Name$ dpDataInicio��5.      $
��Left=�6+   $��24��6F   $��521,104,0,0q�6R   $	��Top=�6g   $	��172��6    J� RenderTransformOrigin$ 0.5,0.5&�6�   {�.  6�   �� 5/   
   $	��ID:��6   $
��Left=�6   $��30��69   $��114,105,0,0q�6E   $	��Top=�6Z   $��46��6r   $��16(�50      $��Copperplate Gothic Bold)�51      ���#2D74E652      �� 53   
   -   5        $ txtID��53      $
��Left=�6!   $��20��6<   $��152,108,0,0q�6H   $
 Wrap=�6]   $	��Top=�6q   $	��175��6�   {�.  6�   �� 54   
   $��Descrição:��6   $
��Left=�6%   $��30��6@   $��
31,192,0,0q�6L   $	��Top=�6`   $	��113��6x   $��16(�55      $��Copperplate Gothic Bold)�56      ���#2D74E657      �� 58   
   -   5        $ txtDescricao��58      $
��Left=�6(   $��59��6C   $��152,197,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��175��6�   {�.  6�     59   
   -   5        $ 	dpDataFim��59      $
��Left=�6(   $��25��6C   $��521,141,0,0q�6O   $	��Top=�6d   $	��172��6|   $ 0.5,0.5&�6�   {�.  6�   �� 5:   
   $��Data Início:��6   $
��Left=�6'   $��30��6B   $��403,101,0,0q�6N   $	��Top=�6c   $	��113��6{   $��16(�5;      $��Copperplate Gothic Bold)�5<      ���#2D74E65=      �� 5>   
   -   5         ��Name$ 	btnEditar��5>      $��Editar��6$   $
��Left=�65   $��40��6P   $��492,363,0,0q�6\   $	��Top=�6q   $	��130��6�   
�������$��Cascadia Code SemiBold)�5@      $��20(�5A       
  Button#��[  5B      ��65   Z� ��5C      �� 5D       �� Color$ 	#FF2259B0��6"    �� Opacity$
 0.85Q�64   5F      �� 5G   
   -	   5        $ btnConcluir��5G      $��Concluir��6&   $��Center=�69   $��40��6V   $��	0,363,0,0q�6b   $	��Top=�6u   $	��128��6�   
�������$��Cascadia Code SemiBold)�5I      $��20(�5J      #��[  5K      ��65   Z� ��5L      �� 5M      $ 	#FF2259B0��6"   $
 0.85Q�64   5O      �� 5P   
   -
   5        $ btnEliminar��5P      $��Eliminar��6&   $
��Left=�69   $��40��6T   $��648,363,0,0q�6`   $	��Top=�6u   $	��129��6�   
�������$��Cascadia Code SemiBold)�5R      $��20(�5S      #��[  5T      ��65   Z� ��5U      �� 5V      $ 	#FF2259B0��6"   $
 0.85Q�64   5X      �� 5Y   
   $��Estado:��6   $
��Left=�6"   $��30��6=   $��
521,15,0,0q�6I   $	��Top=�6]   $	��113��6u   $��16(�5Z      $��Copperplate Gothic Bold)�5[      ���#2D74E65\      �� 5]   
   -   5        $ 	txtEstado��5]      $
��Left=�6%   $��20��6@   $��
598,20,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��123��6�   {�.  6�   �� 5^   
   -   5        $ 
btnGuardar��5^      $��Guardar��6%   $
��Left=�67   $��37��6R   $��	33,30,0,0q�6^   $	��Top=�6q   $	��111��6�   
�������$��Cascadia Code SemiBold)�5`      $��20(�5a      #��[  5b      ��6-   Z� ��5c      �� 5d      $ 	#FF2259B0��6"   $
 0.85Q�64   5f      �� 5g   
   -   5        	 ��Name$
	 A_cb��5g      $��Antecipação��6!   $
��Left=�67   $��
90,328,0,0q�6R   $	��Top=�6f   $��14(�5h      $��Copperplate Gothic Bold)�5i      �� 5j   
   -   5        $	 Nr��5j      $��Não realização��6   $
��Left=�68   $��
90,308,0,0q�6S   $	��Top=�6g   $��14(�5k      $��Copperplate Gothic Bold)�5l      �� 5m   
   -   5        
 ��Name$
 tempo_label��5m      $��Quanto tempo antes:��6%   $
��Left=�6C   $��
64,353,0,0q�6^   $	��Top=�6r   $��16(�6�   $��Copperplate Gothic Bold)�5n      ���#2D74E665   �� 5o   
   -   5        $ tempo_tb��5o      $
��Left=�6$   $��118,381,0,0q�6?   $
 Wrap=�6T   $	��Top=�6h   $	��120��6�   �� 5p   
   -   5        $
 label_horas��5p      $��Horas:��6%   $
��Left=�66   $��
53,377,0,0q�6Q   $	��Top=�6e   $��14(�6}   $��Copperplate Gothic Bold)�5q      �� 5r   
   -   5        $
 	label_min��5r      $��Minutos:��6#   $
��Left=�66   $��
39,401,0,0q�6Q   $	��Top=�6e   $��14(�6}   $��Copperplate Gothic Bold)�5s      �� 5t   
   -   5        $ tempo_minutos��5t      $
��Left=�6)   $��120,406,0,0q�6D   $
 Wrap=�6Y   $	��Top=�6m   $	��120��6�   5u      5v      