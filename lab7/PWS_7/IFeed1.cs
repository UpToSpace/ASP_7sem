///тут контракт службы WCF
///в ин-се поддерж. метод CreateFeed(), возвр. SyndicationFeedFormatter (абс класс)
///возвр класс формата Atom10- или Rss20FeedFormatter
///(эти типы перечисл в ServiceKnownAttribute)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.ServiceModel.Web;
using System.Text;

namespace PWS_7
{
    [ServiceContract]
    [ServiceKnownType(typeof(Atom10FeedFormatter))]
    [ServiceKnownType(typeof(Rss20FeedFormatter))]
    [ServiceKnownType(typeof(List<Note>))]
    public interface IFeed1
    {
        [OperationContract]
        [WebGet(UriTemplate = "students/{studentId}/notes/{formatRequest}", BodyStyle = WebMessageBodyStyle.Bare)]
        SyndicationFeedFormatter GetStudentNotes(string studentId,string formatRequest);
        
    }
}
