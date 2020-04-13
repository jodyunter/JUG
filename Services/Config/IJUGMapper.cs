using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Config
{
    public interface IJUGMapper<TViewModel, TDomainObject, TDAOObject>
    {
        public TViewModel DomainToViewModel(TDomainObject domain);
        public TDomainObject ViewModelToDomain(TViewModel viewModel);
        public TDomainObject DAOToDomain(TDAOObject dao);
        public TDAOObject DomainToDAO(TDomainObject domain);
        
    }
}
