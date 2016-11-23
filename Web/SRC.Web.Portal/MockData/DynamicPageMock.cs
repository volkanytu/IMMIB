using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SRC.Library.Entities;

namespace SRC.Web.Portal.MockData
{
    public static class DynamicPageMock
    {
        public static List<DynamicPage> GetDynamicPages()
        {
            return new List<DynamicPage>
            {
                new DynamicPage
                {
                     Content=@"<div>
                                    <p><strong><font color='#ff0000'>Portale Nasıl Kaydolacağız VOLKAN?</font></strong></p>
                                    <p>Yeni eğitim portalimize hoşgeldiniz. Eğer yeni portalden bir şifre almadı iseniz öncelikle kendinizi sisteme kaydetmeniz gerekiyor. Bunun için &quot;Üyelik Başvurusu&quot; kısmını tıklayarak gerekli bilgileri doldurunuz. Kullanıcı bilgileriniz cep telefonunuza iletilecektir. </p>
                                    <p>Size iletilen şifrenizi isterseniz &quot;Şifre Değiştir&quot; kısmından istediğiniz başka bir şifre ile değiştirebilirsiniz. Yeni şifreniz cep telefonunuza iletilecektir.</p>
                                </div>"
                },
                new DynamicPage
                {
                     Content=@"<div>
                                    <p><font color='#ff0000'><strong>Eğitimlere Nasıl Başvuracağız?</strong></font></p>
                                    <p>Eğitimlerin detaylarını görebilmek için &quot;Eğitim Takvimi&quot; kısmına tıklayınız ve ay seçimi yaparak eğitimlere ulaşınız. Daha fazla bilgi öğrenmek istediğiniz bir eğitim olur ise &quot;Detaylar&quot; kısmını tıkladığınız zaman sayfanın alt tarafında iligli eğitimin detaylarının açıldığını göreceksiniz. </p>
                                    <p>Eğitime başvurmak için &quot;Katılım ve Başvuru&quot; sekmesini tıklayın, katılım sözleşmemizi okuyunuz ve okuduğunuzu teyit ederek katılım talebi oluşturunuz. Talep oluşturduğunuz zaman sistemimizden size bir SMS iletilecek ve katılım detayları hakkında bilgi verecektir.</p>
                                </div>"
                },
                new DynamicPage
                {
                     Content=@" <div>
                                    <p><strong><font color='#ff0000'>Eğitim Ödemelerini Nasıl Yapacağız?</font></strong></p>
                                    <p>Eğitim detaylarında ücret sekmesinde eğitimin ücret bilgileri bulunmaktadır. Eğer bir eğitim ücretli ise o eğitime katılımınız ancak eğitim ücretini, detaylarda belirtilen banka hesabına havale yaptığınız zaman onaylanacaktır.</p>
                                    <p>Havale yaparken açıklama olarak sizlere sistemimizden SMS ile iletilen eğitim katılım kodunu, adınızı ve soyadınızı&nbsp;yazmanızı rica ederiz ki ödemelerinizi rahat ve hızlı bir şekilde onaylayabilelim.</p>
                                </div>"
                }
            };
        }

        public static DynamicPage GetContactPage()
        {
            return new DynamicPage
            {
                Content = @"<p><strong>Adres:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Çobançeşme mevkii, Sanayi Cad. Dış Ticaret Kompleksi A Blok P.K.34197 Yenibosna/Bahçelievler/İSTANBUL <br />
                            <strong>İletişim Bilgileri</strong></p>
                            <p><strong>Ganimet GENÇ Şube Müdürü</strong><br />
                            <strong>Telefon:</strong>&nbsp;&nbsp;&nbsp; &nbsp;+90 212 454 0000/Dahili 1063&nbsp;<br />
                            <strong>E-mail:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='mailto:immib@immib.org.tr'>ganimet.genc@immib.org.tr</a>&nbsp;</p>
                            <p><strong>Selin DOĞAN PEKER&nbsp;Şef</strong><br />
                            <strong>Telefon:</strong>&nbsp;&nbsp;&nbsp; &nbsp;+90 212 454 0000/Dahili 1894&nbsp;<br />
                            <strong>E-mail:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='mailto:ganimet.genc@immib.org.tr'>selin.dogan@immib.org.tr</a>&nbsp;</p>
                            <p><strong>Yasemin COŞMUŞ&nbsp;Uzman </strong></p>
                            <p><strong>Telefon:</strong>&nbsp;&nbsp;&nbsp; &nbsp;+90 212 454 0000/Dahili 1995&nbsp;<br />
                            <strong>E-mail:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='mailto:ganimet.genc@immib.org.tr'>yasemin.cosmus@immib.org.tr</a> </p>
                            <p><iframe height='400' marginheight='0' src='http://maps.google.com/maps/ms?ie=UTF8&amp;hl=tr&amp;t=h&amp;msa=0&amp;msid=115574267836425181606.0004922dec6f8fc2ecc58&amp;ll=41.000646,28.821516&amp;spn=0.006478,0.017595&amp;z=16&amp;iwloc=0004922df1ddd50f15263&amp;output=embed' frameborder='0' width='820' marginwidth='0' scrolling='no'></iframe><br />
                            <small>Şunu daha büyük bir haritada görüntüle: <a style='COLOR: #0000ff; TEXT-ALIGN: left' href='http://maps.google.com/maps/ms?ie=UTF8&amp;hl=tr&amp;t=h&amp;msa=0&amp;msid=115574267836425181606.0004922dec6f8fc2ecc58&amp;ll=41.000646,28.821516&amp;spn=0.006478,0.017595&amp;z=16&amp;iwloc=0004922df1ddd50f15263&amp;source=embed'>İMMİB</a></small></p>",
                PageType = DynamicPage.PageTypeCode.CONTACT.ToOptionSetValueWrapper()
            };
        }

        public static DynamicPage GetHowtoPage()
        {
            return new DynamicPage
            {
                Content = @"NASIL BAŞVURABİLİRİM İÇERİK",
                PageType = DynamicPage.PageTypeCode.TRANSFER_INFORMATION.ToOptionSetValueWrapper()
            };
        }

        public static DynamicPage GetAttendance()
        {
            return new DynamicPage
            {
                Content = @"Başvuru Text",
                PageType = DynamicPage.PageTypeCode.EDUCATION_APPLICATION_CONDITION.ToOptionSetValueWrapper()
            };
        }
    }
}