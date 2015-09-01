<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Goliaz.Web.Admin.EditUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit User</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="hdIdUser" runat="server" />
            <table>
                <tr>
                    <td><h3 id="titlePersonalInf">Personal Information</h3></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="txtEmail" runat="server" Width="250" CssClass="validate" ToolTip="Email" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="txtName" runat="server" Width="250" CssClass="validate" ToolTip="Freeletics Name" ></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="line-height:8px; margin:0px; padding:0px;" >
                        Birth Date
                    </td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="txtBirthDate" runat="server" Width="250" CssClass="validate" ToolTip="Birth Date"  ></asp:TextBox></td>
                </tr>
                <tr>    
                    <td>
                        <asp:DropDownList ID="Nationality" runat="server" style="width:254px; height:25px; font-size: 14px !important;color: #999; " >
                            <asp:ListItem Value="">Select Country...</asp:ListItem>
                            <asp:ListItem Value="Afghanistan">Afghanistan</asp:ListItem>
                            <asp:ListItem Value="Albania">Albania</asp:ListItem>
                            <asp:ListItem Value="Algeria">Algeria</asp:ListItem>
                            <asp:ListItem Value="American Samoa">American Samoa</asp:ListItem>
                            <asp:ListItem Value="Andorra">Andorra</asp:ListItem>
                            <asp:ListItem Value="Angola">Angola</asp:ListItem>
                            <asp:ListItem Value="Anguilla">Anguilla</asp:ListItem>
                            <asp:ListItem Value="Antartica">Antarctica</asp:ListItem>
                            <asp:ListItem Value="Antigua and Barbuda">Antigua and Barbuda</asp:ListItem>
                            <asp:ListItem Value="Argentina">Argentina</asp:ListItem>
                            <asp:ListItem Value="Armenia">Armenia</asp:ListItem>
                            <asp:ListItem Value="Aruba">Aruba</asp:ListItem>
                            <asp:ListItem Value="Australia">Australia</asp:ListItem>
                            <asp:ListItem Value="Austria">Austria</asp:ListItem>
                            <asp:ListItem Value="Azerbaijan">Azerbaijan</asp:ListItem>
                            <asp:ListItem Value="Bahamas">Bahamas</asp:ListItem>
                            <asp:ListItem Value="Bahrain">Bahrain</asp:ListItem>
                            <asp:ListItem Value="Bangladesh">Bangladesh</asp:ListItem>
                            <asp:ListItem Value="Barbados">Barbados</asp:ListItem>
                            <asp:ListItem Value="Belarus">Belarus</asp:ListItem>
                            <asp:ListItem Value="Belgium">Belgium</asp:ListItem>
                            <asp:ListItem Value="Belize">Belize</asp:ListItem>
                            <asp:ListItem Value="Benin">Benin</asp:ListItem>
                            <asp:ListItem Value="Bermuda">Bermuda</asp:ListItem>
                            <asp:ListItem Value="Bhutan">Bhutan</asp:ListItem>
                            <asp:ListItem Value="Bolivia">Bolivia</asp:ListItem>
                            <asp:ListItem Value="Bosnia and Herzegowina">Bosnia and Herzegowina</asp:ListItem>
                            <asp:ListItem Value="Botswana">Botswana</asp:ListItem>
                            <asp:ListItem Value="Bouvet Island">Bouvet Island</asp:ListItem>
                            <asp:ListItem Value="Brazil">Brazil</asp:ListItem>
                            <asp:ListItem Value="British Indian Ocean Territory">British Indian Ocean Territory</asp:ListItem>
                            <asp:ListItem Value="Brunei Darussalam">Brunei Darussalam</asp:ListItem>
                            <asp:ListItem Value="Bulgaria">Bulgaria</asp:ListItem>
                            <asp:ListItem Value="Burkina Faso">Burkina Faso</asp:ListItem>
                            <asp:ListItem Value="Burundi">Burundi</asp:ListItem>
                            <asp:ListItem Value="Cambodia">Cambodia</asp:ListItem>
                            <asp:ListItem Value="Cameroon">Cameroon</asp:ListItem>
                            <asp:ListItem Value="Canada">Canada</asp:ListItem>
                            <asp:ListItem Value="Cape Verde">Cape Verde</asp:ListItem>
                            <asp:ListItem Value="Cayman Islands">Cayman Islands</asp:ListItem>
                            <asp:ListItem Value="Central African Republic">Central African Republic</asp:ListItem>
                            <asp:ListItem Value="Chad">Chad</asp:ListItem>
                            <asp:ListItem Value="Chile">Chile</asp:ListItem>
                            <asp:ListItem Value="China">China</asp:ListItem>
                            <asp:ListItem Value="Christmas Island">Christmas Island</asp:ListItem>
                            <asp:ListItem Value="Cocos Islands">Cocos (Keeling) Islands</asp:ListItem>
                            <asp:ListItem Value="Colombia">Colombia</asp:ListItem>
                            <asp:ListItem Value="Comoros">Comoros</asp:ListItem>
                            <asp:ListItem Value="Congo">Congo</asp:ListItem>
                            <asp:ListItem Value="Congo">Congo, the Democratic Republic of the</asp:ListItem>
                            <asp:ListItem Value="Cook Islands">Cook Islands</asp:ListItem>
                            <asp:ListItem Value="Costa Rica">Costa Rica</asp:ListItem>
                            <asp:ListItem Value="Cota D'Ivoire">Cote d'Ivoire</asp:ListItem>
                            <asp:ListItem Value="Croatia">Croatia (Hrvatska)</asp:ListItem>
                            <asp:ListItem Value="Cuba">Cuba</asp:ListItem>
                            <asp:ListItem Value="Cyprus">Cyprus</asp:ListItem>
                            <asp:ListItem Value="Czech Republic">Czech Republic</asp:ListItem>
                            <asp:ListItem Value="Denmark">Denmark</asp:ListItem>
                            <asp:ListItem Value="Djibouti">Djibouti</asp:ListItem>
                            <asp:ListItem Value="Dominica">Dominica</asp:ListItem>
                            <asp:ListItem Value="Dominican Republic">Dominican Republic</asp:ListItem>
                            <asp:ListItem Value="East Timor">East Timor</asp:ListItem>
                            <asp:ListItem Value="Ecuador">Ecuador</asp:ListItem>
                            <asp:ListItem Value="Egypt">Egypt</asp:ListItem>
                            <asp:ListItem Value="El Salvador">El Salvador</asp:ListItem>
                            <asp:ListItem Value="Equatorial Guinea">Equatorial Guinea</asp:ListItem>
                            <asp:ListItem Value="Eritrea">Eritrea</asp:ListItem>
                            <asp:ListItem Value="Estonia">Estonia</asp:ListItem>
                            <asp:ListItem Value="Ethiopia">Ethiopia</asp:ListItem>
                            <asp:ListItem Value="Falkland Islands">Falkland Islands (Malvinas)</asp:ListItem>
                            <asp:ListItem Value="Faroe Islands">Faroe Islands</asp:ListItem>
                            <asp:ListItem Value="Fiji">Fiji</asp:ListItem>
                            <asp:ListItem Value="Finland">Finland</asp:ListItem>
                            <asp:ListItem Value="France">France</asp:ListItem>
                            <asp:ListItem Value="France Metropolitan">France, Metropolitan</asp:ListItem>
                            <asp:ListItem Value="French Guiana">French Guiana</asp:ListItem>
                            <asp:ListItem Value="French Polynesia">French Polynesia</asp:ListItem>
                            <asp:ListItem Value="French Southern Territories">French Southern Territories</asp:ListItem>
                            <asp:ListItem Value="Gabon">Gabon</asp:ListItem>
                            <asp:ListItem Value="Gambia">Gambia</asp:ListItem>
                            <asp:ListItem Value="Georgia">Georgia</asp:ListItem>
                            <asp:ListItem Value="Germany">Germany</asp:ListItem>
                            <asp:ListItem Value="Ghana">Ghana</asp:ListItem>
                            <asp:ListItem Value="Gibraltar">Gibraltar</asp:ListItem>
                            <asp:ListItem Value="Greece">Greece</asp:ListItem>
                            <asp:ListItem Value="Greenland">Greenland</asp:ListItem>
                            <asp:ListItem Value="Grenada">Grenada</asp:ListItem>
                            <asp:ListItem Value="Guadeloupe">Guadeloupe</asp:ListItem>
                            <asp:ListItem Value="Guam">Guam</asp:ListItem>
                            <asp:ListItem Value="Guatemala">Guatemala</asp:ListItem>
                            <asp:ListItem Value="Guinea">Guinea</asp:ListItem>
                            <asp:ListItem Value="Guinea-Bissau">Guinea-Bissau</asp:ListItem>
                            <asp:ListItem Value="Guyana">Guyana</asp:ListItem>
                            <asp:ListItem Value="Haiti">Haiti</asp:ListItem>
                            <asp:ListItem Value="Heard and McDonald Islands">Heard and Mc Donald Islands</asp:ListItem>
                            <asp:ListItem Value="Holy See">Holy See (Vatican City State)</asp:ListItem>
                            <asp:ListItem Value="Honduras">Honduras</asp:ListItem>
                            <asp:ListItem Value="Hong Kong">Hong Kong</asp:ListItem>
                            <asp:ListItem Value="Hungary">Hungary</asp:ListItem>
                            <asp:ListItem Value="Iceland">Iceland</asp:ListItem>
                            <asp:ListItem Value="India">India</asp:ListItem>
                            <asp:ListItem Value="Indonesia">Indonesia</asp:ListItem>
                            <asp:ListItem Value="Iran">Iran (Islamic Republic of)</asp:ListItem>
                            <asp:ListItem Value="Iraq">Iraq</asp:ListItem>
                            <asp:ListItem Value="Ireland">Ireland</asp:ListItem>
                            <asp:ListItem Value="Israel">Israel</asp:ListItem>
                            <asp:ListItem Value="Italy">Italy</asp:ListItem>
                            <asp:ListItem Value="Jamaica">Jamaica</asp:ListItem>
                            <asp:ListItem Value="Japan">Japan</asp:ListItem>
                            <asp:ListItem Value="Jordan">Jordan</asp:ListItem>
                            <asp:ListItem Value="Kazakhstan">Kazakhstan</asp:ListItem>
                            <asp:ListItem Value="Kenya">Kenya</asp:ListItem>
                            <asp:ListItem Value="Kiribati">Kiribati</asp:ListItem>
                            <asp:ListItem Value="Democratic People's Republic of Korea">Korea, Democratic People's Republic of</asp:ListItem>
                            <asp:ListItem Value="Korea">Korea, Republic of</asp:ListItem>
                            <asp:ListItem Value="Kuwait">Kuwait</asp:ListItem>
                            <asp:ListItem Value="Kyrgyzstan">Kyrgyzstan</asp:ListItem>
                            <asp:ListItem Value="Lao">Lao People's Democratic Republic</asp:ListItem>
                            <asp:ListItem Value="Latvia">Latvia</asp:ListItem>
                            <asp:ListItem Value="Lebanon" >Lebanon</asp:ListItem>
                            <asp:ListItem Value="Lesotho">Lesotho</asp:ListItem>
                            <asp:ListItem Value="Liberia">Liberia</asp:ListItem>
                            <asp:ListItem Value="Libyan Arab Jamahiriya">Libyan Arab Jamahiriya</asp:ListItem>
                            <asp:ListItem Value="Liechtenstein">Liechtenstein</asp:ListItem>
                            <asp:ListItem Value="Lithuania">Lithuania</asp:ListItem>
                            <asp:ListItem Value="Luxembourg">Luxembourg</asp:ListItem>
                            <asp:ListItem Value="Macau">Macau</asp:ListItem>
                            <asp:ListItem Value="Macedonia">Macedonia, The Former Yugoslav Republic of</asp:ListItem>
                            <asp:ListItem Value="Madagascar">Madagascar</asp:ListItem>
                            <asp:ListItem Value="Malawi">Malawi</asp:ListItem>
                            <asp:ListItem Value="Malaysia">Malaysia</asp:ListItem>
                            <asp:ListItem Value="Maldives">Maldives</asp:ListItem>
                            <asp:ListItem Value="Mali">Mali</asp:ListItem>
                            <asp:ListItem Value="Malta">Malta</asp:ListItem>
                            <asp:ListItem Value="Marshall Islands">Marshall Islands</asp:ListItem>
                            <asp:ListItem Value="Martinique">Martinique</asp:ListItem>
                            <asp:ListItem Value="Mauritania">Mauritania</asp:ListItem>
                            <asp:ListItem Value="Mauritius">Mauritius</asp:ListItem>
                            <asp:ListItem Value="Mayotte">Mayotte</asp:ListItem>
                            <asp:ListItem Value="Mexico">Mexico</asp:ListItem>
                            <asp:ListItem Value="Micronesia">Micronesia, Federated States of</asp:ListItem>
                            <asp:ListItem Value="Moldova">Moldova, Republic of</asp:ListItem>
                            <asp:ListItem Value="Monaco">Monaco</asp:ListItem>
                            <asp:ListItem Value="Mongolia">Mongolia</asp:ListItem>
                            <asp:ListItem Value="Montserrat">Montserrat</asp:ListItem>
                            <asp:ListItem Value="Morocco">Morocco</asp:ListItem>
                            <asp:ListItem Value="Mozambique">Mozambique</asp:ListItem>
                            <asp:ListItem Value="Myanmar">Myanmar</asp:ListItem>
                            <asp:ListItem Value="Namibia">Namibia</asp:ListItem>
                            <asp:ListItem Value="Nauru">Nauru</asp:ListItem>
                            <asp:ListItem Value="Nepal">Nepal</asp:ListItem>
                            <asp:ListItem Value="Netherlands">Netherlands</asp:ListItem>
                            <asp:ListItem Value="Netherlands Antilles">Netherlands Antilles</asp:ListItem>
                            <asp:ListItem Value="New Caledonia">New Caledonia</asp:ListItem>
                            <asp:ListItem Value="New Zealand">New Zealand</asp:ListItem>
                            <asp:ListItem Value="Nicaragua">Nicaragua</asp:ListItem>
                            <asp:ListItem Value="Niger">Niger</asp:ListItem>
                            <asp:ListItem Value="Nigeria">Nigeria</asp:ListItem>
                            <asp:ListItem Value="Niue">Niue</asp:ListItem>
                            <asp:ListItem Value="Norfolk Island">Norfolk Island</asp:ListItem>
                            <asp:ListItem Value="Northern Mariana Islands">Northern Mariana Islands</asp:ListItem>
                            <asp:ListItem Value="Norway">Norway</asp:ListItem>
                            <asp:ListItem Value="Oman">Oman</asp:ListItem>
                            <asp:ListItem Value="Pakistan">Pakistan</asp:ListItem>
                            <asp:ListItem Value="Palau">Palau</asp:ListItem>
                            <asp:ListItem Value="Panama">Panama</asp:ListItem>
                            <asp:ListItem Value="Papua New Guinea">Papua New Guinea</asp:ListItem>
                            <asp:ListItem Value="Paraguay">Paraguay</asp:ListItem>
                            <asp:ListItem Value="Peru">Peru</asp:ListItem>
                            <asp:ListItem Value="Philippines">Philippines</asp:ListItem>
                            <asp:ListItem Value="Pitcairn">Pitcairn</asp:ListItem>
                            <asp:ListItem Value="Poland">Poland</asp:ListItem>
                            <asp:ListItem Value="Portugal">Portugal</asp:ListItem>
                            <asp:ListItem Value="Puerto Rico">Puerto Rico</asp:ListItem>
                            <asp:ListItem Value="Qatar">Qatar</asp:ListItem>
                            <asp:ListItem Value="Reunion">Reunion</asp:ListItem>
                            <asp:ListItem Value="Romania">Romania</asp:ListItem>
                            <asp:ListItem Value="Russia">Russian Federation</asp:ListItem>
                            <asp:ListItem Value="Rwanda">Rwanda</asp:ListItem>
                            <asp:ListItem Value="Saint Kitts and Nevis">Saint Kitts and Nevis</asp:ListItem> 
                            <asp:ListItem Value="Saint LUCIA">Saint LUCIA</asp:ListItem>
                            <asp:ListItem Value="Saint Vincent">Saint Vincent and the Grenadines</asp:ListItem>
                            <asp:ListItem Value="Samoa">Samoa</asp:ListItem>
                            <asp:ListItem Value="San Marino">San Marino</asp:ListItem>
                            <asp:ListItem Value="Sao Tome and Principe">Sao Tome and Principe</asp:ListItem> 
                            <asp:ListItem Value="Saudi Arabia">Saudi Arabia</asp:ListItem>
                            <asp:ListItem Value="Senegal">Senegal</asp:ListItem>
                            <asp:ListItem Value="Seychelles">Seychelles</asp:ListItem>
                            <asp:ListItem Value="Sierra">Sierra Leone</asp:ListItem>
                            <asp:ListItem Value="Singapore">Singapore</asp:ListItem>
                            <asp:ListItem Value="Slovakia">Slovakia (Slovak Republic)</asp:ListItem>
                            <asp:ListItem Value="Slovenia">Slovenia</asp:ListItem>
                            <asp:ListItem Value="Solomon Islands">Solomon Islands</asp:ListItem>
                            <asp:ListItem Value="Somalia">Somalia</asp:ListItem>
                            <asp:ListItem Value="South Africa">South Africa</asp:ListItem>
                            <asp:ListItem Value="South Georgia">South Georgia and the South Sandwich Islands</asp:ListItem>
                            <asp:ListItem Value="Span">Spain</asp:ListItem>
                            <asp:ListItem Value="SriLanka">Sri Lanka</asp:ListItem>
                            <asp:ListItem Value="St. Helena">St. Helena</asp:ListItem>
                            <asp:ListItem Value="St. Pierre and Miguelon">St. Pierre and Miquelon</asp:ListItem>
                            <asp:ListItem Value="Sudan">Sudan</asp:ListItem>
                            <asp:ListItem Value="Suriname">Suriname</asp:ListItem>
                            <asp:ListItem Value="Svalbard">Svalbard and Jan Mayen Islands</asp:ListItem>
                            <asp:ListItem Value="Swaziland">Swaziland</asp:ListItem>
                            <asp:ListItem Value="Sweden">Sweden</asp:ListItem>
                            <asp:ListItem Value="Switzerland">Switzerland</asp:ListItem>
                            <asp:ListItem Value="Syria">Syrian Arab Republic</asp:ListItem>
                            <asp:ListItem Value="Taiwan">Taiwan, Province of China</asp:ListItem>
                            <asp:ListItem Value="Tajikistan">Tajikistan</asp:ListItem>
                            <asp:ListItem Value="Tanzania">Tanzania, United Republic of</asp:ListItem>
                            <asp:ListItem Value="Thailand">Thailand</asp:ListItem>
                            <asp:ListItem Value="Togo">Togo</asp:ListItem>
                            <asp:ListItem Value="Tokelau">Tokelau</asp:ListItem>
                            <asp:ListItem Value="Tonga">Tonga</asp:ListItem>
                            <asp:ListItem Value="Trinidad and Tobago">Trinidad and Tobago</asp:ListItem>
                            <asp:ListItem Value="Tunisia">Tunisia</asp:ListItem>
                            <asp:ListItem Value="Turkey">Turkey</asp:ListItem>
                            <asp:ListItem Value="Turkmenistan">Turkmenistan</asp:ListItem>
                            <asp:ListItem Value="Turks and Caicos">Turks and Caicos Islands</asp:ListItem>
                            <asp:ListItem Value="Tuvalu">Tuvalu</asp:ListItem>
                            <asp:ListItem Value="Uganda">Uganda</asp:ListItem>
                            <asp:ListItem Value="Ukraine">Ukraine</asp:ListItem>
                            <asp:ListItem Value="United Arab Emirates">United Arab Emirates</asp:ListItem>
                            <asp:ListItem Value="United Kingdom">United Kingdom</asp:ListItem>
                            <asp:ListItem Value="United States">United States</asp:ListItem>
                            <asp:ListItem Value="United States Minor Outlying Islands">United States Minor Outlying Islands</asp:ListItem>
                            <asp:ListItem Value="Uruguay">Uruguay</asp:ListItem>
                            <asp:ListItem Value="Uzbekistan">Uzbekistan</asp:ListItem>
                            <asp:ListItem Value="Vanuatu">Vanuatu</asp:ListItem>
                            <asp:ListItem Value="Venezuela">Venezuela</asp:ListItem>
                            <asp:ListItem Value="Vietnam">Viet Nam</asp:ListItem>
                            <asp:ListItem Value="Virgin Islands (British)">Virgin Islands (British)</asp:ListItem>
                            <asp:ListItem Value="Virgin Islands (U.S)">Virgin Islands (U.S.)</asp:ListItem>
                            <asp:ListItem Value="Wallis and Futana Islands">Wallis and Futuna Islands</asp:ListItem>
                            <asp:ListItem Value="Western Sahara">Western Sahara</asp:ListItem>
                            <asp:ListItem Value="Yemen">Yemen</asp:ListItem>
                            <asp:ListItem Value="Yugoslavia">Yugoslavia</asp:ListItem>
                            <asp:ListItem Value="Zambia">Zambia</asp:ListItem>
                            <asp:ListItem Value="Zimbabwe">Zimbabwe</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><asp:RadioButtonList ID="rdSex" runat="server" TextAlign="Right" RepeatDirection="Horizontal" RepeatColumns="2" >
                            <asp:ListItem Text="Male" Value="Male" />
                            <asp:ListItem Text="Female" Value="Female" />
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>PB Information</h3>
                    </td>
                </tr>
                <tr>
                    <td style="line-height:8px; margin:0px; padding:0px;">Venus Standard PB</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtVenusPB" CssClass="txtPB" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="line-height:8px; margin:0px; padding:0px;">Poseidon Standard PB</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtPoseidonPB" CssClass="txtPB" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="line-height:8px; margin:0px; padding:0px;">Hades Standard PB</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtHadesPB" CssClass="txtPB" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;">
                        <button id="btnSaveChanges" >Save Changes</button>
                    </td>
                </tr>
            </table>
            <div id="ErrorMessages" style="display:none;">
            </div>
        </div>
    </form>
</body>
</html>
