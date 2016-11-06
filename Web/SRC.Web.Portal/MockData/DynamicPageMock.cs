using SRC.Library.Entities.CrmEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}